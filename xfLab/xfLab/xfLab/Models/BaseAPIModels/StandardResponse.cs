using System;
using System.Collections.Generic;
using System.Text;

namespace xfLab.Models.BaseAPIModels
{
    public class StandardResponse<T>
    {
        public bool Success { get; set; } = false;
        public string StatusCode { get; set; }
        public string ErrorMessage { get; set; } = "";

        /// <summary>
        /// 從網路讀取到的資料的內容(JSON 格式的資料)
        /// </summary>
        public T Payload { get; set; } 
    }
}
