using MIS.IBLL;
using MIS.Model.WorkFlow.WorkFlowInstanceLog;
using MIS.Utility.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MIS.UI.Areas.WorkFlow.ApiControllers
{
    public class WorkFlowInstanceApiController : ApiController
    {
        public IWorkFlowInstanceBLL _workFlowInstanceBLL;

        public WorkFlowInstanceApiController(IWorkFlowInstanceBLL workFlowInstanceBLL)
        {
            this._workFlowInstanceBLL = workFlowInstanceBLL;
        }


        /// <summary>
        /// 添加一个流程实例，默认开始节点为起始节点
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage AddInstanceDraftStep(Guid workFlowChartUniqueId, string name)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowInstanceBLL.AddInstanceDraftStep(workFlowChartUniqueId, name));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 获取流程图的提交按钮
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetWorkFlowInstanceSubmitSelectItem(Guid workFlowInstanceUniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowInstanceBLL.GetWorkFlowInstanceSubmitSelectItem(workFlowInstanceUniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 获取流程图和当前节点的信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetWorkFlowInstanceChart(Guid workFlowInstanceUniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowInstanceBLL.GetWorkFlowInstanceChart(workFlowInstanceUniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        ///  提交操作
        /// </summary>
        /// <param name="workFlowInstanceUniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage WorkFlowInstanceSubmit(WorkFlowInstanceLogInputForm workFlowInstanceLogInputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowInstanceBLL.WorkFlowInstanceSubmit(workFlowInstanceLogInputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

    }
}
