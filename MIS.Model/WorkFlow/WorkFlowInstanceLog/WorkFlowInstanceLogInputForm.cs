using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowInstanceLog
{
  public   class WorkFlowInstanceLogInputForm
    {
     
        /// <summary>
        /// 流程实例的唯一编码
        /// </summary>
        public Guid WorkFlowInstanceUniqueId { get; set; }

       
        /// <summary>
        /// 连线
        /// </summary>
        public Guid LineUniqueId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
