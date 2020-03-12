using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowChart
{
  public  class WorkFlowLineNode
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 连线名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 连线开始节点Id
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 连线结束节点
        /// </summary>
        public string From { get; set; }

        
    }
}
