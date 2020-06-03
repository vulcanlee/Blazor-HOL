using System;
using System.Collections.Generic;
using System.Text;

namespace xfLab.Models.BaseAPIModels
{
    /// <summary>
    /// Manager 通用的回傳結果
    /// </summary>
    public class ManagerResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object WebResponse { get; set; }
        public object ResultData { get; set; }
        public Exception Exception { get; set; }

        public ManagerResult()
        {
            reset();
        }

        public void reset()
        {
            this.Success = false;
            this.Message = "";
            this.WebResponse = null;
            this.ResultData = null;
            this.Exception = null;
        }
    }
}
