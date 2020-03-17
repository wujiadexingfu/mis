using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowInstance;
using MIS.Model.WorkFlow.WorkFlowInstanceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
   public  interface IWorkFlowInstanceBLL
    {
  

        /// <summary>
        /// 获取流程图的提交按钮
        /// </summary>
        /// <param name="workFlowInstanceUniqueId"></param>
        /// <returns></returns>
        List<WorkFlowInstanceSubmitSelectItem> GetWorkFlowInstanceSubmitSelectItem(Guid workFlowInstanceUniqueId);


        /// <summary>
        /// 获取流程图和当前节点的信息
        /// </summary>
        /// <param name="workFlowInstanceUniqueId"></param>
        /// <returns></returns>
        WorkFlowInstanceChart GetWorkFlowInstanceChart(Guid workFlowInstanceUniqueId, string workFlowChartType);


        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="workFlowInstanceLogInputForm"></param>
        /// <returns></returns>
        RequestResult WorkFlowInstanceSubmit(WorkFlowInstanceLogInputForm workFlowInstanceLogInputForm);
    }
}
