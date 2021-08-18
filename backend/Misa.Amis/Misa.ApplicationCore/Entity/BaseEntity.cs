using MISA.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Thuộc tính check để trống
    /// tdanh 7.21
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }
    /// <summary>
    /// Thuộc tính check trùng
    /// tdanh 7.21
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Duplicated : Attribute
    {

    }
    /// <summary>
    /// Thuộc tính khóa chính
    /// tdanh 7.21
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }
    /// <summary>
    /// Tên các cột trong file excel khi import
    /// tdanh 7.21
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelName : Attribute
    {
        public string excel_name { get; set; }
        public ExcelName(string name)
        {
            excel_name = name;
        }
    }
    /// <summary>
    /// Thuộc tính maxlen
    /// tdanh 7.21
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength: Attribute
    {
        /// <summary>
        /// Độ dài cần check
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Tin nhắn báo lỗi
        /// </summary>
        public string ErrorMessage { get; set; }

        public MaxLength(int length, string error_message)
        {
            this.Length = length;
            this.ErrorMessage = error_message;
        }
    }
    public class BaseEntity
    {
        /// <summary>
        /// Trạng thái entity là thêm hay sửa
        /// </summary>
        public EntityState EntityState { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Sửa bởi
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
