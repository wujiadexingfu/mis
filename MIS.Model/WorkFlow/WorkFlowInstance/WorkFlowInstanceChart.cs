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


        /// <summary>
        /// 保存方法
        /// </summary>
        public string SaveFunction { get; set; }

        /// <summary>
        /// 当前action方法
        /// </summary>
        public string ActionUrl { get; set; }
        
        /// <summary>
        /// 是否结束
        /// </summary>
        public bool IsEnd { get; set; }

    }
}
