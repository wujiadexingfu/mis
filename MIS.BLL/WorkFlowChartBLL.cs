using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowChart;
using MIS.Model.WorkFlow.WorkFlowLine;
using MIS.Model.WorkFlow.WorkFlowStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.Utility.Serialize;

namespace MIS.BLL
{
  public   class WorkFlowChartBLL: IWorkFlowChartBLL
    {
        IWorkFlowChartDAL _workFlowChartDAL;
        public WorkFlowChartBLL(IWorkFlowChartDAL workFlowChartDAL)
        {
            _workFlowChartDAL = workFlowChartDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(WorkFlowChartParameter parameter)
        {
            return _workFlowChartDAL.Query(parameter);
        }


        /// 根据UniqueId获取流程图信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public WorkFlowChartInputForm GetItemByUniqueId(Guid uniqueId)
        {
            return _workFlowChartDAL.GetItemByUniqueId(uniqueId);
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(WorkFlowChartInputForm inputForm)
        {
            return _workFlowChartDAL.Add(inputForm);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(WorkFlowChartInputForm inputForm)
        {
            return _workFlowChartDAL.Edit(inputForm);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            return _workFlowChartDAL.Delete(uniqueId);
        }

        /// <summary>
        /// 保存节点，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult SaveWorkFlowStep(WorkFlowStepInputForm inputForm)
        {
            return _workFlowChartDAL.SaveWorkFlowStep(inputForm);
        }

        /// <summary>
        /// 保存连线，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult SaveWorkFlowLine(WorkFlowLineInputForm inputForm)
        {
            return _workFlowChartDAL.SaveWorkFlowLine(inputForm);
        }


        /// <summary>
        /// 保存流程图信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <param name="workFlowChartStepNodes"></param>
        /// <param name="workFlowLineNodes"></param>
        /// <returns></returns>
        public  RequestResult SaveWorkFlowChartContent(WorkFlowChartInputForm inputForm)
        {
            RequestResult result = new RequestResult();
            try
            {

                var workFlowChartNode = JosnNetHelper.JsonToObject<WorkFlowChartNode>(inputForm.FlowChartContent);
                List<WorkFlowStepNode> workFlowChartStepNodes = new List<WorkFlowStepNode>();
                List< WorkFlowLineNode > workFlowLineNodes = new List<WorkFlowLineNode>();


                foreach (var item in workFlowChartNode.Nodes)
                {
                    var node= JosnNetHelper.JsonToObject<WorkFlowStepNode>(item.Value.ToString());
                    node.Id = item.Key;
                    workFlowChartStepNodes.Add(node);
                }

                foreach (var item in workFlowChartNode.Lines)
                {
                    var line = JosnNetHelper.JsonToObject<WorkFlowLineNode>(item.Value.ToString());
                    line.Id = item.Key;
                    workFlowLineNodes.Add(line);
                }
                result = _workFlowChartDAL.SaveWorkFlowChartContent(inputForm, workFlowChartStepNodes, workFlowLineNodes);

            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }

            return result;
        }



        /// <summary>
        /// 获取节点的信息
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        public  WorkFlowStepInputForm GetWorkFlowStepByStepId(string stepId)
        {
            return _workFlowChartDAL.GetWorkFlowStepByStepId(stepId);
        }


        /// <summary>
        ///   获取连线的信息
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public WorkFlowLineInputForm GetWorkFlowLineByLineId(string lineId)
        {
            return _workFlowChartDAL.GetWorkFlowLineByLineId(lineId);
        }

    }
}
