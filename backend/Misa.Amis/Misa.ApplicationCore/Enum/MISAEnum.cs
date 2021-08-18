using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Enum
{
    public enum MISACode
    {
        /// <summary>
        /// trạng thái thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// trạng thái fail
        /// </summary>
        Fail = 500,
        /// <summary>
        /// trạng thái url ko hợp lệ
        /// </summary>
        NotValid = 400,
        /// <summary>
        /// trạng thái thêm thành công
        /// </summary>
        Created = 204,
    }
    public enum EntityState
    {
        Add = 1,
        Update = 2,
        Delete = 3,
    }
}
