using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Tree
{
    public  class TreeNodeState
    {
        /// <summary>
        /// 是否打开
        /// </summary>
        [JsonProperty(PropertyName = "opened")]
        public bool Opened { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// 选中
        /// </summary>
        [JsonProperty(PropertyName = "selected")]
        public bool Selected { get; set; }
    }
}
