using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// tạo interface IDepartmentRepository để thao tác crud với db, giảm sự phụ thuộc giữa các tầng DL, BL, Web
    /// </summary>
    public interface IDepartmentRepository:IBaseRepository<Department>
    {
        /// <summary>
        /// Lấy danh sách tất cả các Departments
        /// </summary>
        /// <returns></returns>
        IEnumerable<Department> GetDepartments();
    }
}
