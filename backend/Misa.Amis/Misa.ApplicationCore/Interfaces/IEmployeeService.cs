using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeService:IBaseService<Employee>
    {
        /// <summary>
        /// Lấy danh sách Employee theo filter
        /// </summary>
        /// <param name="specs"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        ServiceResult GetEmployeesFilter(string filter_val, int pageSize, int pageNumber);

        /// <summary>
        /// Lấy Entity có Max Code
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>
        ServiceResult GetMaxCode();
        /// <summary>
        /// Lấy danh sách employee đã qua format dữ liệu
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>
        ServiceResult GetFormatEmployee();

    }
}
