using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Tree
{
   public  class TreeNode
    {
        /// <summary>
        ///节点
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

   
        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        /// <summary>
        /// 图标
        /// </summary>
        [JsonProperty(PropertyName = "icon")]
        public  string  Icon { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public TreeNodeState State { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public List<TreeNode> Children { get; set; }

        public TreeNode()
        {
            Children = new List<TreeNode>();
            State = new TreeNodeState();
        }
    }
}
