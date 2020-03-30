using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowInstance;
using MIS.Model.WorkFlow.WorkFlowInstanceLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
   public class WorkFlowInstanceBLL:IWorkFlowInstanceBLL
    {
        private IWorkFlowInstanceDAL _workFlowInstanceDAL;
        public WorkFlowInstanceBLL(IWorkFlowInstanceDAL workFlowInstanceDAL)
        {
            _workFlowInstanceDAL = workFlowInstanceDAL;
        }



        /// <summary>
        /// 获取流程图的提交按钮
        /// </summary>
        /// <param name="workFlowInstanceUniqueId"></param>
        /// <returns></returns>
        public List<WorkFlowInstanceSubmitSelectItem> GetWorkFlowInstanceSubmitSelectItem(Guid workFlowInstanceUniqueId, string workFlowChartType)
        {
            return _workFlowInstanceDAL.GetWorkFlowInstanceSubmitSelectItem(workFlowInstanceUniqueId, workFlowChartType);
        }

        /// <summary>
        /// 获取流程图和当前节点的信息
        /// </summary>
        /// <param name="workFlowInstanceUniqueId"></param>
        /// <returns></returns>
        public WorkFlowInstanceChart GetWorkFlowInstanceChart(Guid workFlowInstanceUniqueId, string workFlowChartType)
        {
            return _workFlowInstanceDAL.GetWorkFlowInstanceChart(workFlowInstanceUniqueId, workFlowChartType);
        }


        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="workFlowInstanceLogInputForm"></param>
        /// <returns></returns>
       public RequestResult WorkFlowInstanceSubmit(WorkFlowInstanceLogInputForm workFlowInstanceLogInputForm)
       {
            return _workFlowInstanceDAL.WorkFlowInstanceSubmit(workFlowInstanceLogInputForm);
       }

    }
}
