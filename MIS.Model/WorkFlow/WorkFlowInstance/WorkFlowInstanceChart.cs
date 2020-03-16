using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowInstance
{
   public class WorkFlowInstanceChart
    {
        /// <summary>
        /// 流程图
        /// </summary>
        public string ChartContent { get; set; }

        /// <summary>
        /// 选择节点
        /// </summary>
        public string MarkedId { get; set; }

    }
}
