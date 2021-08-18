using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        #region Declare
        IConfiguration _configuration;
        protected IDbConnection dbConnection;//để protected để class con có thể thực thi Dapper mà ko phải tạo lại connection
        string _tableName;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            //khởi tạo đường dẫn kết nối tới db
            var connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            dbConnection = new MySqlConnection(connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion

        #region Method

        #region Gets
        /// <summary>
        /// Lấy tất cả bản ghi
        /// Định nghĩa hàm GetEntities từ interface IEntityRepository
        /// tdanh 6.21
        /// </summary>
        /// <returns></returns>
        /// 

        public IEnumerable<TEntity> GetEntities()
        {

            //var sqlCommand = "select * from Entity";
            dbConnection.Open();

            var Entities = dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);

            return Entities;
        }
        #endregion

        #region GetById
        /// <summary>
        /// Định nghĩa hàm GetEntityById từ interface IEntityRepository
        /// tdanh 6.21
        /// </summary>
        /// <param name="EntityID"></param>
        /// <returns></returns>
        /// 
        public TEntity GetEntityById(Guid EntityID)
        {

            //Add parameter
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add($"{_tableName}Id", EntityID.ToString());

            //var sqlCommand = $"select * from Entity where EntityId = '{EntityID.ToString()}'";
            dbConnection.Open();
            var Entity = dbConnection.QueryFirstOrDefault<TEntity>($"Proc_Get{_tableName}ById", param: dynamicParam, commandType: CommandType.StoredProcedure);

            return Entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// Định nghĩa hàm InsertEntity từ interface IEntityRepository
        /// tdanh 6.21
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public int InsertEntity(TEntity Entity)
        {
            var result = 0;
            var dynamicParam = MapDbType(Entity);

            //Mở kết nối đến db
            dbConnection.Open();

            //Sử dụng transaction khi có trường hợp thêm nhiều Entity nhưng xảy ra lỗi thì db sẽ ko bị ảnh hưởng
            //using (var transaction = dbConnection.BeginTransaction())
            //{
                result = dbConnection.Execute($"Proc_Insert{_tableName}", param: dynamicParam, commandType: CommandType.StoredProcedure);
            //    transaction.Commit();
            //}



            return result;
        }
        #endregion

        #region Update
        /// <summary>
        /// Định nghĩa hàm UpdateEntity từ interface IEntityRepository
        /// tdanh 6.21
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public int UpdateEntity(TEntity Entity)
        {

            var result = 0;
            var dynamicParam = MapDbType(Entity);

            dbConnection.Open();

            //Sử dụng transaction trong TH nhiều entity nhưng xảy ra lỗi
            //using (var transaction = dbConnection.BeginTransaction())
            //{

                result = dbConnection.Execute($"Proc_Update{_tableName}", param: dynamicParam, commandType: CommandType.StoredProcedure);
            //    transaction.Commit();

            //}
            return result;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Định nghĩa hàm DeleteEntity từ interface IEntityRepository
        /// tdanh 6.21
        /// </summary>
        /// <param name="EntityID"></param>
        /// <returns></returns>
        public int DeleteEntity(Guid EntityID)
        {
            var result = 0;

            //Add parameter
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add($"Id", EntityID.ToString());


            dbConnection.Open();

            //using (var transaction = dbConnection.BeginTransaction())
            //{
                result = dbConnection.Execute($"Proc_Delete{_tableName}ById", param: dynamicParam, commandType: CommandType.StoredProcedure);
            //    transaction.Commit();
            //}

            return result;
        }
        #endregion

        #region Map
        /// <summary>
        /// Add các parameter từ model cùng kiểu dbtype
        /// tdanh 6.21
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DynamicParameters MapDbType(TEntity entity)
        {
            //Add parameter
            var dynamicParam = new DynamicParameters();
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;

                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    dynamicParam.Add($"{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    dynamicParam.Add($"{propertyName}", propertyValue, DbType.String);
                }
            }

            return dynamicParam;
        }
        #endregion

        #region GetByProperty
        /// <summary>
        /// Lấy value by tên property
        /// tdanh 7.21
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public TEntity GetValueEntityByPropertyName(TEntity entity, PropertyInfo property)
        {
            var IdValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);

            var query = string.Empty;

            //Với state là thêm mới, kiểm tra trùng bằng cách tìm trong db có bản ghi nào có các trường giống với entity
            if (entity.EntityState == ApplicationCore.Enum.EntityState.Add)
            {
                query = $"Select * from {_tableName} where {property.Name} = '{property.GetValue(entity)}'";

            }
            //Nếu là sửa thì TEntityId phải khác nhau mới tính là bị trùng
            else if (entity.EntityState == ApplicationCore.Enum.EntityState.Update)
            {
                query = $"Select * from {_tableName} where {property.Name} = '{property.GetValue(entity)}' && {_tableName}Id <> '{IdValue}'";
            }
            else
            {
                return null;
            }

            var result = dbConnection.Query<TEntity>(query, commandType: CommandType.Text);
            return result.FirstOrDefault();
        }
        #endregion

        #region CountEntity
        /// <summary>
        /// Lấy tổng số bản ghi
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>
        public int GetCountEntity()
        {
            var result = dbConnection.ExecuteScalar<int>($"select count(*) from {_tableName}");
            return result;
        }
        #endregion

        #region Paging
        /// <summary>
        /// Lấy entity theo phân trang
        /// tdanh 7.21
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetEntitiesPaging(int pageIndex, int pageSize)
        {

            DynamicParameters dynamic_param = new DynamicParameters();
            dynamic_param.Add($"pageIndex", pageIndex);
            dynamic_param.Add($"pageSize", pageSize);

            var result = dbConnection.Query<TEntity>($"Proc_Get{_tableName}Paging", param: dynamic_param, commandType: CommandType.StoredProcedure);

            return result;
        }
        #endregion

        #region ExistCode
        /// <summary>
        /// kiểm tra tồn tại EntityCode
        /// tdanh 7.21
        /// </summary>
        /// <param name="entity_code"></param>
        /// <param name="entity_id"></param>
        /// <returns></returns>
        public bool CheckEntityCodeExist(string entity_code)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add($"{_tableName}Code", entity_code, DbType.String);

            var result = dbConnection.Query<bool>($"Proc_Check{_tableName}CodeExist", param:param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }
        #endregion

        /// <summary>
        /// Đóng kết nối khi transaction failed
        /// </summary>
        public void Dispose()
        {
            if (dbConnection.State == ConnectionState.Open)
            {
                dbConnection.Close();
            }
        }
        #endregion
    }
}
