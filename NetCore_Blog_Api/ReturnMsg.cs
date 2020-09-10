using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Blog_Api
{
    /// <summary>
    /// 公用的返回消息格式
    /// </summary>
    public class ReturnMsg
    {
        /// <summary>
        /// 返回的Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public string Data { get; set; }
    }
}
