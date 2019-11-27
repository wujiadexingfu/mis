using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Result
{
    public class RequestResult
    {
        /// <summary>
        /// 是否正确
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 成功方法
        /// </summary>
        public void Success()
        {
            this.IsSuccess = true;
            this.Message = string.Empty;
            this.Data = null;

        }

        /// <summary>
        /// 返回数据方法
        /// </summary>
        /// <param name="Data"></param>
        public void ReturnData(object Data)
        {
            this.IsSuccess = true;
            this.Message = string.Empty;
            this.Data = Data;

        }

        /// <summary>
        /// 返回错误方法
        /// </summary>
        /// <param name="Message"></param>
        public void ReturnFailedMessage(string Message)
        {
            this.IsSuccess = false;
            this.Message = Message;
            this.Data = null;
        }
    }
}
