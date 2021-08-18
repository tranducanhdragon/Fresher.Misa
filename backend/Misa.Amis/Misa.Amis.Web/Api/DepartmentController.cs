using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using Dapper;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Entity;
using System.Threading;
using System.IO;
using OfficeOpenXml;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Api
{
    /// <summary>
    /// controller xử lý nghiệp vụ liên quan tới đối tượng Department
    /// tdanh 05.07.21
    /// </summary>
    [Route("v1/departments")]
    [ApiController]
    public class DepartmentController : BaseEntityController<Department>
    {
        //Được gọi từ tầng BL, implement từ interface IDepartmentService
        IDepartmentService department_ser;


        public DepartmentController(IDepartmentService _department_ser):base(_department_ser)
        {
            department_ser = _department_ser;
        }

 
    }
}
