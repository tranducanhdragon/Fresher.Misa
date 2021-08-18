using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    public class Employee:BaseEntity
    {
        /// <summary>
        /// Khóa chính-EmployeeId
        /// </summary>
        [PrimaryKey]
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// check để trống, check trùng mã employeeCode
        /// </summary>
        ///
        [ExcelName("Mã nhân viên")]
        [Required]
        [Duplicated]
        [DisplayName("Mã nhân viên")]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// check maxlen tên nhân viên
        /// </summary>
        /// 
        [ExcelName("Họ và tên")]
        [Required]
        [MaxLength(50,"Độ dài tối là là 50 ký tự")]
        [DisplayName("Họ và tên")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        /// 
        [ExcelName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        /// 
        [ExcelName("Địa chỉ")]
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        //[Duplicated]
        [ExcelName("Di động")]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// 
        [ExcelName("Điện thoại cố định")]
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// Giới tính enum
        /// </summary>
        /// 
        [ExcelName("Giới tính")]
        public int? Gender { get; set; }
        //[Duplicated]
        [ExcelName("Email")]
        [DisplayName("Email")]
        public string Email { get; set; }
        /// <summary>
        /// Số CMND
        /// </summary>
        /// 
        [ExcelName("CMND")]
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        /// 
        [ExcelName("Ngày cấp CMND")]
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Địa điểm cấp CMND
        /// </summary>
        /// 
        [ExcelName("Nơi cấp CMND")]
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Chức vụ nhân viên
        /// </summary>
        /// 
        [ExcelName("Chức vụ")]
        public string EmployeePosition { get; set; }
        /// <summary>
        /// Số tài khoản ngân hàng của nhân viên
        /// </summary>
        /// 
        [ExcelName("Tài khoản ngân hàng")]
        public string BankAccountNumber { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// 
        [ExcelName("Tên ngân hàng")]
        public string BankName { get; set; }
        /// <summary>
        /// Tên chi nhánh ngân hàng
        /// </summary>
        /// 
        [ExcelName("Tên chi nhánh ngân hàng")]
        public string BankBranchName { get; set; }
        /// <summary>
        /// Tên tỉnh thành của ngân hàng
        /// </summary>
        /// 
        [ExcelName("Tỉnh thành ngân hàng")]
        public string BankProvinceName { get; set; }
        /// <summary>
        /// Id phòng ban của nhân viên đó, ko được null
        /// </summary>
        [Required]
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// tình trạng công việc
        /// </summary>
        /// 

        public string WorkStatusName { get; set; }
        /// <summary>
        /// tên phòng ban, ko được null
        /// </summary>
        /// 
        [ExcelName("Phòng ban")]
        [Required]
        public string DepartmentName { get; set; }
    }
}
