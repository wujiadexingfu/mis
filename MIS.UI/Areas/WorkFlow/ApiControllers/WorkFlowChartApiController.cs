using MIS.IBLL;
using MIS.Model.WorkFlow.WorkFlowChart;
using MIS.Model.WorkFlow.WorkFlowInstanceLog;
using MIS.Model.WorkFlow.WorkFlowLine;
using MIS.Model.WorkFlow.WorkFlowStep;
using MIS.UI.Filters;
using MIS.Utility.GuidUtility;
using MIS.Utility.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.UI.Areas.WorkFlow.ApiControllers
{
    public class WorkFlowChartApiController : ApiController
    {
        private IWorkFlowChartBLL _workFlowChartBLL;
        public WorkFlowChartApiController(IWorkFlowChartBLL workFlowChartBLL)
        {
            this._workFlowChartBLL = workFlowChartBLL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [OperationFilterAttribute(OperationType.Query)]
        public HttpResponseMessage Query(WorkFlowChartParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm">修改参数</param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Edit)]
        [HttpPost]
        public HttpResponseMessage Edit(WorkFlowChartInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.Edit(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm">新增参数</param>
        /// <returns></returns>
        [HttpPost]
        [OperationFilterAttribute(OperationType.Add)]
        public HttpResponseMessage Add(WorkFlowChartInputForm inputForm)
        {
            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.Add(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 根据唯一编码获取流程图信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemByUniqueId(Guid uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.GetItemByUniqueId(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId">唯一编码</param>
        /// <returns></returns>
        [HttpGet]
        [OperationFilterAttribute(OperationType.Delete)]
        public HttpResponseMessage Delete(Guid uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 获取到一个Guid
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetGuid()
        {
            var guid = GuidUtils.NewGuid().ToString();
    
            return new HttpResponseMessage()
            {
                Content = new StringContent(guid, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 保存节点，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage SaveWorkFlowStep(WorkFlowStepInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.SaveWorkFlowStep(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 保存连线，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage SaveWorkFlowLine(WorkFlowLineInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.SaveWorkFlowLine(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 保存流程图信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage SaveWorkFlowChartContent(WorkFlowChartInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.SaveWorkFlowChartContent(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 获取节点的信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetWorkFlowStepByStepId(string stepId)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.GetWorkFlowStepByStepId(stepId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 获取节点的信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetWorkFlowLineByLineId(string lineId)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.GetWorkFlowLineByLineId(lineId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 获取流程日志
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetWorkFlowInstanceLogs(WorkFlowInstanceLogParameter parameter)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowChartBLL.GetWorkFlowInstanceLogs(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        

    }
}
