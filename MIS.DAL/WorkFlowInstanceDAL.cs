using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowInstance;
using MIS.Model.WorkFlow.WorkFlowInstanceLog;
using MIS.Utility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.DAL
{
  public  class WorkFlowInstanceDAL:IWorkFlowInstanceDAL
    {

        private ISysLogDAL _sysLogDAL;
        public WorkFlowInstanceDAL(ISysLogDAL sysLogDAL)
        {
            _sysLogDAL = sysLogDAL;
        }

        /// <summary>
        /// 添加一个流程实例，默认开始节点为起始节点
        /// </summary>
        /// <param name="workFlowChartUniqueId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public RequestResult AddInstanceDraftStep(string name, WorkFlowChartType workFlowChartType) 
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();

                var workFlowChart = db.WorkFlow_Chart.Where(x => x.WorkFlowType == workFlowChartType.ToString()).FirstOrDefault();

                
                var firstStep = db.WorkFlow_Step.Where(x => x.WorkFlowChartUniqueId == workFlowChart.UniqueId && x.IsBegin == true).FirstOrDefault();
                if (firstStep == null)
                {
                    result.ReturnFailedMessage("没有设置起始节点!");
                }
                else
                {
                    WorkFlow_Instance instance = new WorkFlow_Instance();
                    instance.UniqueId = GuidUtils.NewGuid();
                    instance.Name = name;
                    instance.WorkFlowChartUniqueId = workFlowChart.UniqueId;
                    instance.CurrentStepUniqueId = firstStep.UniqueId;
                    instance.CurrentStepName = firstStep.Name;
                    instance.CreateTime = DateTime.Now;
                    instance.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.WorkFlow_Instance.Add(instance);
                    db.SaveChanges();
                    result.ReturnData(instance.UniqueId);
                }  

            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;

        }

        /// <summary>
        /// 获取流程图的提交按钮
        /// </summary>
        /// <param name="workFlowInstanceUniqueId"></param>
        /// <returns></returns>
        public List<WorkFlowInstanceSubmitSelectItem> GetWorkFlowInstanceSubmitSelectItem(Guid workFlowInstanceUniqueId,string workFlowChartType)
        {
            List<WorkFlowInstanceSubmitSelectItem> list = new List<WorkFlowInstanceSubmitSelectItem>();
            MISEntities db = new MISEntities();

            var workFlowInstance = db.WorkFlow_Instance.Where(x => x.UniqueId == workFlowInstanceUniqueId).FirstOrDefault();
            if (workFlowInstance != null)
            {
                var currentStepUniqueId = workFlowInstance.CurrentStepUniqueId; //当前流程所在节点的状态
                var stepLineList = db.view_workflowStepLine.Where(x => x.FromStepUniqueId == currentStepUniqueId).ToList();
                foreach (var item in stepLineList)
                {
                    WorkFlowInstanceSubmitSelectItem selectItem = new WorkFlowInstanceSubmitSelectItem();
                    selectItem.Text = item.Name;
                    selectItem.Value = item.LineUniqueId.ToString();
                    list.Add(selectItem);
                }
            }
            else
            {
                var stepLineList = db.view_workflowStepLine.Where(x => x.WorkFlowType == workFlowChartType && x.IsBegin == true).ToList();
                foreach (var item in stepLineList)
                {
                    WorkFlowInstanceSubmitSelectItem selectItem = new WorkFlowInstanceSubmitSelectItem();
                    selectItem.Text = item.Name;
                    selectItem.Value = item.LineUniqueId.ToString();
                    list.Add(selectItem);
                }

            }

           
            return list;
        }

        /// <summary>
        /// 获取流程图和当前节点的信息
        /// </summary>
        /// <param name="workFlowInstanceUniqueId"></param>
        /// <param name="workFlowChartType"></param>
        /// <returns></returns>
        public WorkFlowInstanceChart GetWorkFlowInstanceChart(Guid workFlowInstanceUniqueId,string workFlowChartType)
        {

            MISEntities db = new MISEntities();
            WorkFlowInstanceChart item = new WorkFlowInstanceChart();
            if (workFlowInstanceUniqueId.ToString() == Constant.GuidEmpty)
            {
                var workFlowChart = db.WorkFlow_Chart.Where(x => x.WorkFlowType == workFlowChartType).FirstOrDefault();
                item.ChartContent = workFlowChart.FlowChartContent;
                var firstStep = db.WorkFlow_Step.Where(x => x.WorkFlowChartUniqueId == workFlowChart.UniqueId && x.IsBegin == true).FirstOrDefault();
                item.MarkedId = firstStep.StepId;
                item.SaveFunction = firstStep.SaveFunction;


            }
            else
            {
                var instance = db.WorkFlow_Instance.Where(x => x.UniqueId == workFlowInstanceUniqueId).FirstOrDefault();

                item.ChartContent = db.WorkFlow_Chart.Where(x => x.UniqueId == instance.WorkFlowChartUniqueId.Value).FirstOrDefault().FlowChartContent;

                var step = db.WorkFlow_Step.Where(x => x.UniqueId == instance.CurrentStepUniqueId).FirstOrDefault();
                item.MarkedId = step.StepId;
                item.SaveFunction = step.SaveFunction;
            }



           

            return item;
        }


        /// <summary>
        /// 提交操作
        /// </summary>
        /// <param name="workFlowInstanceLogInputForm"></param>
        /// <returns></returns>
        public RequestResult WorkFlowInstanceSubmit(WorkFlowInstanceLogInputForm workFlowInstanceLogInputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var instance = db.WorkFlow_Instance.Where(x => x.UniqueId == workFlowInstanceLogInputForm.WorkFlowInstanceUniqueId).FirstOrDefault();
                var workFlowStepLine = db.view_workflowStepLine.Where(x => x.LineUniqueId == workFlowInstanceLogInputForm.LineUniqueId).FirstOrDefault();

                instance.CurrentStepName = workFlowStepLine.ToStepName;
                instance.CurrentStepUniqueId = workFlowStepLine.ToStepUniqueId;

                instance.ModifyTime = DateTime.Now;
                instance.ModifyUser = SessionUtils.GetAccountUnqiueId(); 


                WorkFlow_InstanceLog workFlowInstanceLog = new WorkFlow_InstanceLog();
                workFlowInstanceLog.UniqueId = GuidUtils.NewGuid();
                workFlowInstanceLog.WorkFlowChartUniqueId = instance.WorkFlowChartUniqueId;

                workFlowInstanceLog.WorkFlowInstanceUniqueId = workFlowInstanceLogInputForm.WorkFlowInstanceUniqueId;
                workFlowInstanceLog.FromStepUniqueId = workFlowStepLine.FromStepUniqueId;
                workFlowInstanceLog.ToStepUniqueId = workFlowStepLine.ToStepUniqueId;
                workFlowInstanceLog.LineUniqueId = workFlowInstanceLogInputForm.LineUniqueId;
                workFlowInstanceLog.Remark = workFlowInstanceLogInputForm.Remark;
                workFlowInstanceLog.CreateUser = SessionUtils.GetAccountUnqiueId();
                workFlowInstanceLog.CreateTime = DateTime.Now;


                db.WorkFlow_InstanceLog.Add(workFlowInstanceLog);

                db.SaveChanges();
                result.Success();

            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;

        }



    }
}
