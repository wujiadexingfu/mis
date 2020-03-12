using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowLine
{
    public class WorkFlowLineInputForm
    {
        /// <summary>
        /// 连线的Id
        /// </summary>
        public string LineId { get; set; }


        /// <summary>
        /// 流程图的唯一编码
        /// </summary>
        public Guid? WorkFlowChartUniqueId { get; set; }

        /// <summary>
        /// 连线的名称
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 连线类型
        /// </summary>
        public string LineType { get; set; }

        /// <summary>
        /// 连线的开始节点Id
        /// </summary>
        public string FromStepId { get; set; }

        /// <summary>
        /// 连线的结束节点Id
        /// </summary>
        public string ToStepId { get; set; }

    }
}
