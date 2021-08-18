using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {

        #region Declare
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {
            //_configuration = configuration;

            ////khởi tạo đường dẫn kết nối tới db
            //var connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            //dbConnection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Định nghĩa hàm GetCustomers từ interface ICustomerRepository
        /// tdanh 6.21
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetDepartments()
        {           

            //var sqlCommand = "select * from Customer";
            dbConnection.Open();

            var departments = dbConnection.Query<Department>("Proc_GetDepartments", commandType: CommandType.StoredProcedure);

            return departments;
        }


        /// <summary>
        /// Add các parameter từ model cùng kiểu dbtype
        /// tdanh 6.21
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DynamicParameters MapDbType<TEntity>(TEntity entity)
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
    }
}
