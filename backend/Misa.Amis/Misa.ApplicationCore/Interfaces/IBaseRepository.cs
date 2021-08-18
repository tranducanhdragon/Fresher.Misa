using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy danh sách tất cả các Entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntities();
        /// <summary>
        /// Lấy danh sách Entity theo EntityID
        /// </summary>
        /// <param name="EntityID"></param>
        /// <returns></returns>
        TEntity GetEntityById(Guid EntityID);
        /// <summary>
        /// thêm một Entity
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        int InsertEntity(TEntity Entity);
        /// <summary>
        /// Update một Entity
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        int UpdateEntity(TEntity Entity);
        /// <summary>
        /// Xóa một Entity theo EntityID
        /// </summary>
        /// <param name="EntityID"></param>
        /// <returns></returns>
        int DeleteEntity(Guid EntityID);
        /// <summary>
        /// Lấy giá trị của property đó trong TEntity
        /// </summary>
        /// <returns></returns>
        TEntity GetValueEntityByPropertyName(TEntity entity, PropertyInfo property);
        /// <summary>
        /// Lấy tổng số bản ghi
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>
        int GetCountEntity();
        /// <summary>
        /// Lấy dữ liệu theo phân trang
        /// tdanh 6.21
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntitiesPaging(int pageIndex, int pageSize);
        /// <summary>
        /// Check tồn tại mã code trong db
        /// </summary>
        /// <param name="entity_code"></param>
        /// <returns></returns>
        bool CheckEntityCodeExist(string entity_code);
    }
}
