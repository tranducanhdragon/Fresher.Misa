using Misa.ApplicationCore.Entity;
using MISA.ApplicationCore.Entity;
using Misa.ApplicationCore.Properties;
using MISA.ApplicationCore.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.ApplicationCore
{
    //Kế thừa từ BaseService chứa các method chung như CRUD
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IEmployeeRepository employee_repo;
        ServiceResult result;

        //Kế thừa từ BaseService
        public EmployeeService(IEmployeeRepository _employee_repo) : base(_employee_repo)
        {
            employee_repo = _employee_repo;
            result = new ServiceResult();
        }
        #endregion

        //public ServiceResult DeleteEmployee(Guid EmployeeID)
        //{
        //    throw new NotImplementedException();
        //}

        //public Employee GetEmployeeById(Guid EmployeeID)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Employee> GetEmployees()
        //{
        //    throw new NotImplementedException();
        //}
        #region Method

        #region Insert
        /// <summary>
        /// Ghi đè lại method InsertEntity từ cha
        /// tdanh 6.21
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public override ServiceResult InsertEntity(Employee Employee)
        {

            //Validate dữ liệu
            var isValid = true;

            ////Check trùng mã
            //var dupCode = employee_repo.GetEmployeeByCode(Employee.EmployeeCode);
            //if(dupCode != null)
            //{
            //    isValid = false;
            //    result.Messenger = "Trùng mã EmployeeCode";
            //}
            ////Check trùng số điện thoai
            //var dupPhone = employee_repo.GetEmployeeByPhoneNumber(Employee.PhoneNumber);
            //if (dupPhone!= null)
            //{
            //    isValid = false;
            //    result.Messenger = "Trùng số điện thoại";
            //}

            ////Check trùng email
            //var dupEmail = employee_repo.GetEmployeeByEmail(Employee.Email);
            //if (dupEmail != null)
            //{
            //    isValid = false;
            //    result.Messenger = "Trùng email";
            //}


            if (isValid)
            {
                //Gọi đến hàm InsertEntity từ cha
                return base.InsertEntity(Employee);
            }
            else
            {
                result.Data = null;
                result.MISACode = Enum.MISACode.Fail;
                result.Messenger = Resources.MisaFail;
                return result;
            }


        }
        #endregion

        #region Update
        /// <summary>
        /// Sửa nhân viên
        /// tdanh 7.21
        /// </summary>
        /// <param name="Employee"></param>
        /// <returns></returns>
        public ServiceResult UpdateEmployee(Employee Employee)
        {
            //validate dữ liệu theo Employee


            //Gọi đến hàm UpdateEntity từ cha
            result.Data = base.UpdateEntity(Employee);
            return result;
        }
        #endregion

        #region FilterPaging
        /// <summary>
        /// Lấy dữ liệu trả về theo phân trang, có filter theo tên và employeeCode
        /// tdanh 7.21
        /// </summary>
        /// <param name="filter_val"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public ServiceResult GetEmployeesFilter(string filter_val, int pageSize, int pageNumber)
        {
            var data_paging = new List<Employee>();
            //Lấy tổng số bản ghi
            if (filter_val != null)
            {
                data_paging = (List<Employee>)employee_repo.GetEmployeesFilter(filter_val, pageSize, pageNumber);
            }
            else
            {
                data_paging = (List<Employee>)employee_repo.GetEntities();
            }

            var totalRecord = data_paging.Count;
            var totalPage = (totalRecord/pageSize) + 1;

            result.Data = new Paging{
                totalPage = totalPage,
                totalRecord = totalRecord,
                data = employee_repo.GetEmployeesFilter(filter_val, pageSize, pageNumber),
            };
            result.MISACode = Enum.MISACode.Success;
            result.Messenger = Resources.MisaSuccess;


            return result;
        }
        #endregion

        #region MaxCode
        /// <summary>
        /// Lấy mã mới trong db
        /// tdanh 7.21
        /// </summary>
        /// <returns></returns>

        public ServiceResult GetMaxCode()
        {
            var max_code = employee_repo.GetMaxCode();

            //tách chuỗi để sinh mã mới
            var ten_dau = "";
            var number = "";

            for (int i = 0; i < max_code.Length; ++i)
            {

                if (!Char.IsDigit(max_code[i]))
                {
                    ten_dau += max_code[i];
                }
                else
                {
                    number += max_code[i];
                }
            }

            var new_code = ten_dau + (Int32.Parse(number) + 1).ToString();

            result.Data = new_code;
            result.MISACode = Enum.MISACode.Success;
            result.Messenger = Resources.MisaSuccess;
            return result;
        }
        #endregion

        #region Format
        /// <summary>
        /// hàm format lại data thô để xuất ra excel
        /// tdanh 7.21
        /// </summary>
        /// <param name="listEmployees"></param>
        public ServiceResult GetFormatEmployee()
        {
            List<EmployeeExcel> listEmployeeExcel = new List<EmployeeExcel>();

            var employees = employee_repo.GetEntities();
            foreach(var employee in employees)
            {
                var employeeExcel = FormatData(employee);
                listEmployeeExcel.Add(employeeExcel);
            }

            result.Data = listEmployeeExcel;
            result.MISACode = Enum.MISACode.Success;
            result.Messenger = Resources.MisaSuccess;

            return result;
        }
        public EmployeeExcel FormatData(Employee employee)
        {
            EmployeeExcel employeeExcel = new EmployeeExcel();

            var properties = employee.GetType().GetProperties();
            foreach(var property in properties)
            {
                //map employee với employeeExcel

                var propertyName = property.Name;
                var propertyValue = property.GetValue(employee);

                //Nếu tồn tại thuộc tính trong employeeExcel trùng với thuộc tính trong employee
                var propertyEmployeeExcel = employeeExcel.GetType().GetProperty(propertyName);

                if (propertyEmployeeExcel != null && property.GetValue(employee) != null)
                {
                    var employeeExcelValue = employeeExcel.GetType().GetProperty(propertyName);
                    if (property.PropertyType == typeof(DateTime?))
                    {
                        //Giá trị cần gán vào employeeExcel
                        var value = propertyValue.ToString();

                        //Cắt chuỗi ngày/tháng/năm bằng cách lấy từ đầu đến dấu cách đầu tiên
                        employeeExcelValue.SetValue(employeeExcel,value.Substring(0, value.IndexOf(' ')));
                    }
                    else if(property.Name == "Gender") 
                    {
                        if((int)property.GetValue(employee) == 0)
                        {
                            employeeExcelValue.SetValue(employeeExcel, "Nữ");
                        }
                        else if((int)property.GetValue(employee) == 1)
                        {
                            employeeExcelValue.SetValue(employeeExcel, "Nam");
                        }
                        else
                        {
                            employeeExcelValue.SetValue(employeeExcel, "Khác");
                        }
                    }
                    else
                    {
                        employeeExcelValue.SetValue(employeeExcel, property.GetValue(employee).ToString());
                    }

                }
                

            }

            return employeeExcel;
        }
        #endregion


        //PHẦN IMPLEMENT CHO INTERFACE IEmployeeService, ko dùng BASE


        ////Employee_repo được gọi từ tầng Data Layer và implement từ interface IEmployeeRepository
        ////Interface ko thể được khởi tạo vì nó là abtract
        //IEmployeeRepository Employee_repo;

        //public EmployeeService(IEmployeeRepository _Employee_repo)
        //{
        //    //nhưng đối tượng implement của interface đó có thể được khởi tạo
        //    Employee_repo = _Employee_repo;
        //}


        ///// <summary>
        ///// get all Employees from Data layer
        ///// tdanh 6.21
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<Employee> GetEmployees()
        //{
        //    //var Employee_context = new EmployeeContext();

        //    //return Employee_context.GetEmployees();


        //    //Gọi EmployeeContext thông qua interface, tránh sự phụ thuộc giữa các tầng
        //    return Employee_repo.GetEmployees();

        //}
        ///// <summary>
        ///// get Employee by ID from Data Layer
        ///// tdanh 6.21
        ///// </summary>
        ///// <param name="EmployeeID"></param>
        ///// <returns></returns>
        //public Employee GetEmployeeById(Guid EmployeeID)
        //{
        //    //var Employee_context = new EmployeeContext();

        //    //return Employee_context.GetEmployeeById(EmployeeID);


        //    return Employee_repo.GetEmployeeById(EmployeeID);

        //}
        ///// <summary>
        ///// insert Employee from Data layer
        ///// tdanh 6.21
        ///// </summary>
        ///// <param name="Employee"></param>
        ///// <returns></returns>
        //public ServiceResult InsertEmployee(Employee Employee)
        //{
        //    //var Employee_context = new EmployeeContext();
        //    //trạng thái trả về
        //    var serviceResult = new ServiceResult();

        //    //validate dữ liệu trước khi xuống tầng Data Layer
        //    //check mã để trống
        //    if (string.IsNullOrEmpty(Employee.EmployeeCode))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeCode", msg = "Null" },
        //            userMsg = "Mã khách hàng không được trống",
        //            code = 400,
        //        };
        //        serviceResult.Data = msg;
        //        serviceResult.MISACode = 400;
        //        serviceResult.Messenger = "Lỗi mã khách hàng đang để trống";

        //    }
        //    //check trùng EmployeeId



        //    //var result = Employee_context.InsertEmployee(Employee);
        //    //gọi bằng cách dùng interface
        //    var result = Employee_repo.InsertEmployee(Employee);

        //    if (result > 0)
        //    {
        //        serviceResult.Data = result;
        //        serviceResult.Messenger = "Thêm thành công";
        //        serviceResult.MISACode = 204;
        //    }

        //    return serviceResult;
        //}
        ///// <summary>
        ///// Update Employee from Data Layer
        ///// tdanh 6.21
        ///// </summary>
        ///// <param name="Employee"></param>
        ///// <returns></returns>
        //public ServiceResult UpdateEmployee(Employee Employee)
        //{
        //    //var Employee_context = new EmployeeContext();
        //    var serviceRresult = new ServiceResult();
        //    //validate



        //    //var result = Employee_context.UpdateEmployee(Employee);
        //    //gọi bằng cách dùng interface
        //    var result = Employee_repo.UpdateEmployee(Employee);

        //    if (result > 0)
        //    {
        //        serviceRresult.Data = result;
        //        serviceRresult.Messenger = "Cập nhật thành công";
        //        serviceRresult.MISACode = 200;
        //    }
        //    else
        //    {
        //        serviceRresult.Data = result;
        //        serviceRresult.Messenger = "Cập nhật thất bại";
        //        serviceRresult.MISACode = 500;
        //    }

        //    return serviceRresult;
        //}

        //public ServiceResult DeleteEmployee(Guid EmployeeID)
        //{
        //    //var Employee_context = new EmployeeContext();
        //    var serviceResult = new ServiceResult();

        //    //var result = Employee_context.DeleteEmployeeByID(EmployeeID);
        //    //gọi bằng cách dùng interface
        //    var result = Employee_repo.DeleteEmployee(EmployeeID);

        //    if (result > 0)
        //    {
        //        serviceResult.Data = result;
        //        serviceResult.Messenger = "Xóa thành công";
        //        serviceResult.MISACode = 200;
        //    }

        //    return serviceResult;
        //}

        #endregion
    }

}
