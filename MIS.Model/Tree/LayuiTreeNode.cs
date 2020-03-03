using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Tree
{
  public  class LayuiTreeNode
    {
        /// <summary>
        /// 节点唯一编号
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 节点标题
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public List<LayuiTreeNode> Children { get; set; }


        /// <summary>
        /// 是否选中
        /// </summary>
        [JsonProperty(PropertyName = "checked")]
        public bool Checked{ get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        public string NodeType { get; set; }


        public LayuiTreeNode()
        {
            this.Children = new List<LayuiTreeNode>();
        }


    }
}
