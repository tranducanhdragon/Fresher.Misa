using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.ApplicationCore.Entity;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Api
{
    [Route("v1/employees")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        #region Declare
        //Được gọi từ tầng BL, implement từ interface IEmployeeService
        IEmployeeService Employee_ser;


        public EmployeeController(IEmployeeService _Employee_ser) : base(_Employee_ser)
        {
            Employee_ser = _Employee_ser;
        }

        #endregion

        #region PagingFilter
        /// <summary>
        /// Lấy dữ liệu Employee theo filter EmployeeCode, FullName, PhoneNumber
        /// tdanh 6.21
        /// </summary>
        /// <param name="specs"></param>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpGet("filter")]
        public IActionResult GetFilter([FromQuery] string filter_val, [FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            var result = Employee_ser.GetEmployeesFilter(filter_val, pageSize, pageNumber);
            return Ok(result);
        }
        #endregion

        #region MaxCode
        /// <summary>
        /// Lấy dữ liệu entity có max code
        /// tdanh 22.6.21
        /// </summary>
        /// <param name="BaseID"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowCROSPolicy")]
        [HttpGet]
        [Route("max_code")]
        public IActionResult GetMaxCode()
        {

            var result = Employee_ser.GetMaxCode();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(502, "Không tìm thấy");
            }
        }
        #endregion

        #region ExportFilter
        /// <summary>
        /// Export theo phân trang và filter
        /// tdanh 7.21
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="filter_val"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [EnableCors("AllowCROSPolicy")]
        [HttpGet("export_paging")]
        public async Task<IActionResult> ExportPaging(CancellationToken cancellationToken, [FromQuery] string filter_val, [FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            var result = Employee_ser.GetEmployeesFilter(filter_val, pageSize, pageIndex);

            // query data from database  
            await Task.Yield();
            //chuyển về kiểu Paging
            var paging = (Paging)result.Data;
            var list = (List<Employee>)paging.data;


            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Employee-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        #endregion

        #region Export
        /// <summary>
        /// Export all
        /// tdanh 7.21
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EnableCors("AllowCROSPolicy")]
        [HttpGet("export")]
        public async Task<IActionResult> Export(CancellationToken cancellationToken)
        {
            var result = Employee_ser.GetFormatEmployee();

            // query data from database  
            await Task.Yield();

            var list = (List<EmployeeExcel>)result.Data;

            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);


                //Set row height cho các ô
                workSheet.DefaultRowHeight = 20;
                workSheet.DefaultColWidth = 20;

                //căn lề dữ liệu
                //Duyệt từng hàng
                for(int i = 1; i <= list.Count + 1; ++i)
                {
                    var colProperty = list[0].GetType().GetProperties();
                    for(int j = 1; j <= colProperty.Length; ++j)
                    {
                        if (colProperty[j - 1].Name == "DateOfBirth" || colProperty[j - 1].Name == "Gender" || colProperty[j - 1].Name == "IdentityDate")
                        {
                            workSheet.Cells[i, j].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        }
                        else if (colProperty[j - 1].Name == "IdentityNumber" || colProperty[j - 1].Name == "BankAccountNumber")
                        {
                            workSheet.Cells[i, j].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        }
                        else
                        {
                            workSheet.Cells[i, j].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        }
                    }
                }


                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Employee-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        #endregion

    }
}
