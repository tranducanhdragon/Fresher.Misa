using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Api
{
    [Route("v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        #region Declare
        //Được gọi từ tầng BL, implement từ interface IBaseService
        IBaseService<TEntity> base_ser;


        public BaseEntityController(IBaseService<TEntity> _base_ser)
        {
            base_ser = _base_ser;
        }
        #endregion

        #region Gets
        /// <summary>
        /// lấy dữ liệu entity
        /// tdanh 22.6.21
        /// </summary>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpGet]
        public IActionResult Get()
        {

            //var Base_bussiness = new BaseService();

            //var Bases = Base_bussiness.GetBases();

            var entities = base_ser.GetEntities();
            if (entities != null)
            {
                return Ok(entities);
            }
            else
            {
                return StatusCode(502, "Không tìm thấy");
            }
        }
        #endregion

        #region GetById
        /// <summary>
        /// Lấy dữ liệu entity theo ID
        /// tdanh 22.6.21
        /// </summary>
        /// <param name="BaseID"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpGet]
        [Route("{EntityID}")]
        public IActionResult GetByID([FromRoute] Guid EntityID)
        {
            //var Base_bussiness = new BaseService();

            //var Base = Base_bussiness.GetBaseByID(BaseID);

            //Gọi bằng cách sử dụng interface
            var entity = base_ser.GetEntityById(EntityID);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return StatusCode(502, "Không tìm thấy");
            }
        }
        #endregion

        #region Insert
        /// <summary>
        /// insert dữ liệu entity
        /// tdanh 22.6.21
        /// </summary>
        /// <param name="Base"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpPost]
        public IActionResult Insert(TEntity entity)
        {
            //var Base_bussiness = new BaseService();
            //var result = Base_bussiness.InsertBase(Base);


            //Gọi bằng cách dùng interface
            var result = base_ser.InsertEntity(entity);

            return Ok(result);

        }
        #endregion

        #region Update
        /// <summary>
        /// update dữ liệu entity
        /// tdanh 22.6.21
        /// </summary>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpPut("{EntityID}")]
        public IActionResult Update(Guid EntityID, TEntity entity)
        {
            //var Base_business = new BaseService();
            //var result = Base_business.UpdateBase(Base);

            //gọi bằng cách dùng interface
            var result = base_ser.UpdateEntity(entity);

            return Ok(result);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// xóa dữ liệu của một entity
        /// tdanh 22.6.21
        /// </summary>
        /// <param name="BaseID"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpDelete]
        [Route("{EntityID}")]
        public IActionResult Delete(Guid EntityID)
        {
            //var Base_business = new BaseService();
            //var result = Base_business.DeleteBase(BaseID);

            //gọi bằng cách dùng interface
            var result = base_ser.DeleteEntity(EntityID);

            return Ok(result);
        }
        #endregion

        #region ExistCode
        /// <summary>
        /// Kiểm tra entity code trong db đã tồn tại hay chưa
        /// tdanh 7.21
        /// </summary>
        /// <param name="BaseID"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpGet("check_exist")]
        public IActionResult CheckEntityCodeExist([FromQuery] string EntityCode)
        {

            var entity = base_ser.CheckEntityCodeExist(EntityCode);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return StatusCode(502, "Không tìm thấy");
            }
        }
        #endregion

        #region Paging
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// tdanh 7.21
        /// </summary>
        /// 
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpGet("paging")]
        public IActionResult GetEntitiesPaging([FromQuery] int pageIndex, [FromQuery] int pageSize)
        {

            var entity = base_ser.GetEntitiesPaging(pageIndex, pageSize);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return StatusCode(500, "Không tìm thấy");
            }
        }
        #endregion

    }
}
