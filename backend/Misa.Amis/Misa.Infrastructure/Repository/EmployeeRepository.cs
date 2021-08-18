using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    public class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
    {
        #region Declare
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion

        #region Method

        #region GetByCode
        /// <summary>
        /// Lấy employee theo Code
        /// tdanh 7.21
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <returns></returns>
        public Employee GetEmployeeByCode(string EmployeeCode)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeCode", EmployeeCode, DbType.String);

            var result = dbConnection.Query<Employee>($"Select * from Employee where EmployeeCode = @EmployeeCode", param: param, commandType: CommandType.Text);
            return result.FirstOrDefault();
        }
        #endregion

        #region GetByPhone
        /// <summary>
        /// Lấy employee theo PhoneNumber
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public Employee GetEmployeeByPhoneNumber(string PhoneNumber)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PhoneNumber", PhoneNumber, DbType.String);

            var result = dbConnection.Query<Employee>($"Select * from Employee where PhoneNumber = @PhoneNumber", param: param, commandType: CommandType.Text);
            return result.FirstOrDefault();
        }
        #endregion

        #region GetByEmail
        /// <summary>
        /// Lấy employee theo Email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Employee GetEmployeeByEmail(string Email)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Email", Email, DbType.String);

            var result = dbConnection.Query<Employee>($"Select * from Employee where Email = @Email", param:param, commandType: CommandType.Text);
            return result.FirstOrDefault();
        }
        #endregion

        #region PagingFilter
        /// <summary>
        /// Tìm kiếm theo phân trang
        /// tdanh 7.21
        /// </summary>
        /// <param name="filter_val"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployeesFilter(string filter_val, int pageSize, int pageNumber)
        {
            DynamicParameters para = new DynamicParameters();
            para.Add("FilterValue", filter_val, DbType.String);
            para.Add("PageSize", pageSize, DbType.Int32);
            para.Add("PageNum", pageNumber, DbType.Int32);


            var result = dbConnection.Query<Employee>("Proc_GetEmployeesFilter", param:para ,commandType:CommandType.StoredProcedure);
            return result;
        }
        #endregion

        #region MaxCode
        /// <summary>
        /// Lấy max code
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>
        public string GetMaxCode()
        {
            var result = dbConnection.Query<string>($"Proc_GetMaxEmployeeCode", commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;

        }
        #endregion

        #endregion
    }
}
