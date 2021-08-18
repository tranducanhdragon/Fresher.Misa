using MISA.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entity
{
    /// <summary>
    /// Dữ liệu trả về theo kiểu RestFul
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set;}
        /// <summary>
        /// tin nhắn trả về
        /// </summary>
        public string Messenger { get; set; }
        /// <summary>
        /// status code của misa
        /// </summary>
        public MISACode MISACode { get; set; }
        /// <summary>
        /// hàm gán ServiceResult
        /// </summary>
        /// <param name="mISACode"></param>
        /// <param name="messenger"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ServiceResult GetResult(MISACode mISACode, string messenger, object data = default(object))
        {
            return new ServiceResult
            {
                MISACode = mISACode,
                Messenger = messenger,
                Data = data
            };
        }
    }

    public class Paging
    {
        /// <summary>
        /// tổng số trang
        /// </summary>
        public int totalPage { get; set; }
        /// <summary>
        /// tổng bản ghi
        /// </summary>
        public int totalRecord { get; set; }
        /// <summary>
        /// dữ liệu của trang đó
        /// </summary>
        public object data { get; set; }
    }
}
