using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowChart
{
    public class WorkFlowStepNode
    {
        /// <summary>
        /// 节点的编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 节点的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 横坐标
        /// </summary>

        public string Left { get; set; }

        /// <summary>
        /// 纵坐标
        /// </summary>

        public string Top { get; set; }



    }
}
