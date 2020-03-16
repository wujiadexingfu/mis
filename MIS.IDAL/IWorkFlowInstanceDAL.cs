using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowInstance;
using MIS.Model.WorkFlow.WorkFlowInstanceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
   public  interface IWorkFlowInstanceDAL
    {
        /// <summary>
        /// 添加一个流程实例，默认开始节点为起始节点
        /// </summary>
        /// <param name="workFlowChartUniqueId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        RequestResult AddInstanceDraftStep(Guid workFlowChartUniqueId, string name);


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
        WorkFlowInstanceChart GetWorkFlowInstanceChart(Guid workFlowInstanceUniqueId);



        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="workFlowInstanceLogInputForm"></param>
        /// <returns></returns>
        RequestResult WorkFlowInstanceSubmit(WorkFlowInstanceLogInputForm workFlowInstanceLogInputForm);
    }
}
