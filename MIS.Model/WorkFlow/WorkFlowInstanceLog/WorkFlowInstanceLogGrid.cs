using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowInstanceLog
{
     public  class WorkFlowInstanceLogGrid
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// 上一节点
        /// </summary>
        public string FromStepName { get; set; }

        /// <summary>
        /// 提交方式
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public string CreateTime { get; set; }

    }
}
