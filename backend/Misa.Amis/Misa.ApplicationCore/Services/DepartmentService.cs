using MISA.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.IO;
using OfficeOpenXml;

namespace MISA.ApplicationCore
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        #region Declare
        //customer_repo được gọi từ tầng Data Layer và implement từ interface ICustomerRepository
        //Interface ko thể được khởi tạo vì nó là abtract
        IDepartmentRepository department_repo;


        public DepartmentService(IDepartmentRepository _department_repo) : base(_department_repo)
        {
            //nhưng đối tượng implement của interface đó có thể được khởi tạo
            department_repo = _department_repo;
        }
        #endregion

        #region Method
        /// <summary>
        /// Import data từ file excel
        /// tdanh 7.21
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public override ServiceResult ImportEntity(IFormFile formFile, CancellationToken cancellationToken)
        {

            ServiceResult result = base.ImportEntity(formFile, cancellationToken);

            return result;
        }
 
        /// <summary>
        /// validate custom
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        protected override bool ValidateCustom(Department department)
        {
            var isVal = true;

            if (isVal)
            {

            }

            return isVal;
        }
        #endregion
    }
}
