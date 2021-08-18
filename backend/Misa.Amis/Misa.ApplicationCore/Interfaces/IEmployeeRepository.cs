using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        /// <summary>
        /// Lấy thông tin Employee theo EmployeeCode
        /// tdanh 6.21
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <returns></returns>
        Employee GetEmployeeByCode(string EmployeeCode);
        /// <summary>
        /// Lấy thông tin Employee theo PhoneNumber
        /// tdanh 6.21
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        Employee GetEmployeeByPhoneNumber(string PhoneNumber);
        /// <summary>
        /// Lấy thông tin Employee theo Email
        /// tdanh 6.21
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        Employee GetEmployeeByEmail(string Email);
        /// <summary>
        /// Lấy dữ liệu Employee theo filter
        /// tdanh 6.21
        /// </summary>
        /// <param name="specs"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployeesFilter(string filter_val, int pageSize, int pageNumber);
        /// <summary>
        /// Lấy max code theo createdDate
        /// </summary>
        /// <returns></returns>
        string GetMaxCode();


    }
}
