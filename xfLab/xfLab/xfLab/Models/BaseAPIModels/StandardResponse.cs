using System;
using System.Collections.Generic;
using System.Text;

namespace xfLab.Models.BaseAPIModels
{
    public class StandardResponse
    {
        /// <summary>
        /// 0: 正常、其他: 異常代碼
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// 從網路讀取到的資料的內容(JSON 格式的資料)
        /// </summary>
        public string Data { get; set; }
    }
}
