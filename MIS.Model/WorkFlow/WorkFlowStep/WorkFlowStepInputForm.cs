using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowStep
{
   public  class WorkFlowStepInputForm
    {
        /// <summary>
        /// 流程图的唯一编码
        /// </summary>
        public Guid? WorkFlowChartUniqueId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 节点Id
        /// </summary>
        public string StepId { get; set; }
        
        /// <summary>
        /// 横坐标
        /// </summary>

        public double? StepLeft { get; set; }

        /// <summary>
        /// 纵坐标
        /// </summary>
        public double? StepTop { get; set; }

        /// <summary>
        /// 节点状态
        /// </summary>
        public String StepState { get; set; }

        /// <summary>
        /// 审核类型
        /// </summary>
        public string AuditingType { get; set; }

        /// <summary>
        /// 是否为起始节点
        /// </summary>
        public bool? IsBegin { get; set; }

        /// <summary>
        /// 链接路径
        /// </summary>
        public string ActionUrl { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public Guid? StepRole { get; set; }

        /// <summary>
        /// 保存方法
        /// </summary>
        public string SaveFunction { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }


    }
}
