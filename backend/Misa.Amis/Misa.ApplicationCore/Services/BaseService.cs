using Microsoft.AspNetCore.Http;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using Misa.ApplicationCore.Properties;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        #region Declare
        IBaseRepository<TEntity> base_repo;
        ServiceResult result;

        public BaseService(IBaseRepository<TEntity> _base_repo)
        {
            base_repo = _base_repo;
            result = new ServiceResult() { Messenger = "Thành công", MISACode = Enum.MISACode.Success };
        }
        #endregion

        #region Method
        #region Delete
        /// <summary>
        /// Xóa bản ghi theo id
        /// tdanh 7.21
        /// </summary>
        /// <param name="EntityID"></param>
        /// <returns></returns>
        public ServiceResult DeleteEntity(Guid EntityID)
        {
            result.Data = base_repo.DeleteEntity(EntityID);
            result.MISACode = Enum.MISACode.Success;
            result.Messenger = Resources.MisaSuccess;
            return result;
        }
        #endregion

        #region Gets
        /// <summary>
        /// Lấy tất cả bản ghi
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntities()
        {
            return base_repo.GetEntities();
        }
        #endregion

        #region GetByID
        /// <summary>
        /// lấy bản ghi by ID
        /// tdanh 7.21
        /// </summary>
        /// <param name="EntityID"></param>
        /// <returns></returns>
        public TEntity GetEntityById(Guid EntityID)
        {
            return base_repo.GetEntityById(EntityID);
        }
        #endregion

        #region Insert
        /// <summary>
        /// insert entity
        /// tdanh 7.21
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public virtual ServiceResult InsertEntity(TEntity Entity)
        {
            //Thêm trạng thái cho TEntity( chỉ khi TEntity này đang kế thừa từ BaseEntity)
            Entity.EntityState = Enum.EntityState.Add;

            var isVal = this.Validate(Entity);
            if (isVal)
            {
                result.Data = base_repo.InsertEntity(Entity);
                result.MISACode = Enum.MISACode.Success;
                result.Messenger = Resources.MisaSuccess;
                return result;
            }
            else
            {
                result.Messenger = "Thêm thất bại";
                result.MISACode = Enum.MISACode.Fail;
                result.Messenger = Resources.MisaFail;
                return result;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Sửa entity
        /// tdanh 7.21
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public virtual ServiceResult UpdateEntity(TEntity Entity)
        {
            //Thêm trạng thái cho TEntity( chỉ khi TEntity này đang kế thừa từ BaseEntity)
            Entity.EntityState = Enum.EntityState.Update;

            var isVal = this.Validate(Entity);
            if (isVal)
            {

                result.Data = base_repo.UpdateEntity(Entity);
                result.MISACode = Enum.MISACode.Success;
                result.Messenger = Resources.MisaSuccess;
                return result;
            }
            else
            {
                result.Messenger = "Cập nhật thất bại";
                result.MISACode = Enum.MISACode.Fail;
                result.Messenger = Resources.MisaFail;
                return result;
            }
        }
        #endregion

        #region Paging
        /// <summary>
        /// Get dữ liệu phân trang
        /// tdanh 7.21
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ServiceResult GetEntitiesPaging(int pageIndex, int pageSize)
        {
            var records = base_repo.GetCountEntity();
            var totalPage = (int)(records / pageSize) + 1;

            result.Data = new Paging
            {
                totalPage = totalPage,
                totalRecord = records,
                data = base_repo.GetEntitiesPaging(pageIndex, pageSize),
            };

            result.MISACode = Enum.MISACode.Success;
            result.Messenger = Resources.MisaSuccess;

            return result;
        }
        #endregion

        #region ExistCode
        /// <summary>
        /// Kiểm tra tồn tại code trong db
        /// tdanh 7.21
        /// </summary>
        /// <param name="entity_code"></param>
        /// <param name="entity_id"></param>
        /// <returns></returns>
        public ServiceResult CheckEntityCodeExist(string entity_code)
        {
            result.Data = base_repo.CheckEntityCodeExist(entity_code);
            result.MISACode = Enum.MISACode.Success;
            result.Messenger = Resources.MisaSuccess;

            return result;
        }
        #endregion

        #region Import
        /// <summary>
        /// Import dữ liệu từ file excel
        /// tdanh 7.21
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual ServiceResult ImportEntity(IFormFile formFile, CancellationToken cancellationToken)
        {

            if (formFile == null || formFile.Length <= 0)
            {
                return ServiceResult.GetResult(Enum.MISACode.Fail, "formfile is empty");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return ServiceResult.GetResult(Enum.MISACode.Fail, "Not Support file extension");
            }

            var list = new List<TEntity>();

            using (var stream = new MemoryStream())
            {
                formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var colCount = worksheet.Dimension.Columns;

                    for (int row = 3; row <= rowCount; row++)
                    {
                        var entity = (TEntity)Activator.CreateInstance(typeof(TEntity), new object[] { });

                        this.BuildObject(worksheet, row, colCount, ref entity);

                        list.Add(entity);
                    }
                }
            }
            ServiceResult result = new ServiceResult();
            result.Data = list;
            result.MISACode = Enum.MISACode.Success;
            result.Messenger = Resources.MisaSuccess;


            return result;
        }
        /// <summary>
        /// Build bảng trong excel
        /// tdanh 7.21
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="row"></param>
        /// <param name="totalCol"></param>
        /// <param name="entity"></param>
        private void BuildObject(ExcelWorksheet worksheet, int row, int totalCol, ref TEntity entity)
        {

            //Duyệt các cột trong file excel
            for (int col = 1; col <= totalCol; ++col)
            {
                //Check validate trong tệp


                //Map dữ liệu trong excel với entity
                var cellValue = worksheet.Cells[row, col].Value;
                var colName = worksheet.Cells[2, col].Value;
                this.MapExcelToEntity(ref cellValue, ref entity, colName.ToString());

            }


        }
        /// <summary>
        /// Map dữ liệu từ excel với entity
        /// tdanh 6.21
        /// </summary>
        /// <param name="cellValue"></param>
        /// <param name="entity"></param>
        /// <param name="colName"></param>
        private void MapExcelToEntity(ref object cellValue, ref TEntity entity, string colName)
        {
            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                //Kiểm tra xem property đó có attribute ExcelName ko
                if (property.IsDefined(typeof(ExcelName), false))
                {
                    var attribute = property.GetCustomAttributes(typeof(ExcelName), true)[0];

                    var excel_name = (attribute as ExcelName).excel_name;

                    if (colName == excel_name.ToString() && cellValue != null)
                    {
                        if (property.PropertyType == typeof(DateTime?))
                        {
                            property.SetValue(entity, DateTime.ParseExact(cellValue.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            property.SetValue(entity, cellValue.ToString());
                        }

                    }

                }

            }
        }
        #endregion


        #region Validate
        /// <summary>
        /// Validate theo propertyName
        /// tdanh 6.21
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool Validate(TEntity entity)
        {
            var isValid = true;
            var properties = entity.GetType().GetProperties();
            var messageArr = new List<string>();

            foreach (var property in properties)
            {

                //Kiểm tra có attribute là Required ko
                if (property.IsDefined(typeof(Required), false))
                {
                    //check để trống
                    var propertyValue = property.GetValue(entity);
                    //var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    if (propertyValue == null)
                    {

                        result.MISACode = Enum.MISACode.Fail;
                        messageArr.Add($"{property.Name} đang để trống");
                        isValid = false;
                    }

                }
                //Kiểm tra có attribute là Duplicated ko
                if (property.IsDefined(typeof(Duplicated), false))
                {
                    //check trùng trong db
                    var propertyValue = base_repo.GetValueEntityByPropertyName(entity, property);
                    //var displayName = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    if (propertyValue != null)
                    {
                        result.MISACode = Enum.MISACode.Fail;
                        messageArr.Add($"{property.Name} đã tồn tại");
                        isValid = false;
                    }
                }

                //Kiểm tra có attribute là MaxLength ko
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    //kiểm tra độ dài của property
                    var attributeMaxLengh = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var max_len = (attributeMaxLengh as MaxLength).Length;
                    var error_mes = (attributeMaxLengh as MaxLength).ErrorMessage;

                    if (property.GetValue(entity).ToString().Trim().Length > max_len)
                    {
                        result.MISACode = Enum.MISACode.Fail;
                        messageArr.Add($"{property.Name} {error_mes}");
                        isValid = false;
                    }
                }
            }
            result.Data = messageArr;

            //validate custom được override từ các con
            this.ValidateCustom(entity);

            return isValid;
        }
        /// <summary>
        /// Validate custom tùy theo đối tượng Entity
        /// tdanh .21
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateCustom(TEntity entity)
        {
            //Mở ra để các thằng con override lại
            return true;
        }
        #endregion

        #endregion
    }
}
