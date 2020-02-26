using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Page
{
   public class PageData
    {
        /// <summary>
        /// 返回代码类型
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty(PropertyName = "msg")]
        public string Msg { get; set; }


        public PageData(int count, object data)
        {
            this.Count = count;
            this.Data = data;
        }

        public PageData(int count, object data, string msg)
        {
            this.Count = count;
            this.Msg = msg;
            this.Data = data;
        }
    }
}
