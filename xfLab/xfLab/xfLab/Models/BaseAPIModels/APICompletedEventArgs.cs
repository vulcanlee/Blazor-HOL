using System;
using System.Collections.Generic;
using System.Text;

namespace xfLab.Models.BaseAPIModels
{
    public class APICompletedEventArgs : EventArgs
    {
        #region Fields
        /// <summary>
        /// 回傳給 ViewModel 的物件.
        /// </summary>
        private object _result;

        /// <summary>
        /// 錯誤訊息.
        /// </summary>
        private Exception _exception;

        #endregion

        #region property.
        /// <summary>
        /// 回傳給 ViewModel 的物件.
        /// </summary>
        public object Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        /// <summary>
        /// 錯誤訊息.
        /// </summary>
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
            }
        }
        #endregion

        #region method.

        /// <summary>
        /// Constructor.
        /// </summary>
        public APICompletedEventArgs(Object result, Exception e)
        {
            this._result = result;
            this._exception = e;
        }

        #endregion
    }
}
