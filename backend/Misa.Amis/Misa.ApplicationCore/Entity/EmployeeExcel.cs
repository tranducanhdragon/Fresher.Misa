using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misa.ApplicationCore.Entity
{
    public class EmployeeExcel
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// 
        [DisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// tên nhân viên
        /// </summary>
        /// 
        [DisplayName("Họ và tên")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        /// 
        [DisplayName("Ngày sinh")]
        public string DateOfBirth { get; set; }
        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        /// 
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// 
        [DisplayName("Số di động")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// 
        [DisplayName("Số cố định")]
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// Giới tính enum
        /// </summary>
        /// 
        [DisplayName("Giới tính")]
        public string Gender { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// 
        [DisplayName("Email")]
        public string Email { get; set; }
        /// <summary>
        /// Số CMND
        /// </summary>
        /// 
        [DisplayName("Số CMND")]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        /// 
        [DisplayName("Ngày cấp")]
        public string IdentityDate { get; set; }
        /// <summary>
        /// Địa điểm cấp CMND
        /// </summary>
        /// 
        [DisplayName("Nơi cấp")]
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Chức vụ nhân viên
        /// </summary>
        /// 
        [DisplayName("Chức vụ")]
        public string EmployeePosition { get; set; }
        /// <summary>
        /// Số tài khoản ngân hàng của nhân viên
        /// </summary>
        /// 
        [DisplayName("Số tài khoản")]
        public string BankAccountNumber { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// 
        [DisplayName("Ngân hàng")]
        public string BankName { get; set; }
        /// <summary>
        /// Tên chi nhánh ngân hàng
        /// </summary>
        /// 
        [DisplayName("Chi nhánh")]
        public string BankBranchName { get; set; }
        /// <summary>
        /// Tên tỉnh thành của ngân hàng
        /// </summary>
        ///
        [DisplayName("Tỉnh thành")]
        public string BankProvinceName { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// 
        [DisplayName("Phòng ban")]
        public string DepartmentName { get; set; }
    }
}
