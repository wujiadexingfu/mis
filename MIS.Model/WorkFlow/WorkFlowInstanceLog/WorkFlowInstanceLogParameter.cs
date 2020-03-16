using MIS.Model.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowInstanceLog
{
   public  class WorkFlowInstanceLogParameter:BaseParameter
    {
        /// <summary>
        /// 流程实例的唯一编码
        /// </summary>
        public Guid WorkFlowInstanceUniqueId { get; set; }
    }
}
