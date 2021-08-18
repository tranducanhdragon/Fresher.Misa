using Microsoft.AspNetCore.Http;
using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
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
        ServiceResult InsertEntity(TEntity Entity);
        /// <summary>
        /// Update một Entity
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        ServiceResult UpdateEntity(TEntity Entity);
        /// <summary>
        /// Xóa một Entity theo EntityID
        /// </summary>
        /// <param name="EntityID"></param>
        /// <returns></returns>
        ServiceResult DeleteEntity(Guid EntityID);

        /// <summary>
        /// Lấy dữ liệu Entity theo phân trang
        /// tdanh 6.21
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        ServiceResult GetEntitiesPaging(int pageIndex, int pageSize);
        /// <summary>
        /// Import dữ liệu Entity từ file excel
        /// tdanh 7.21
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        ServiceResult ImportEntity(IFormFile formFile, CancellationToken cancellationToken);

        /// <summary>
        /// Kiểm tra tồn tại mã code trong db
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>
        ServiceResult CheckEntityCodeExist(string entity_code);
    }
}
