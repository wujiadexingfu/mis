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
using static MIS.Utility.EnumUtility.SystemEnums;

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
        /// 获取流程图的提交按钮
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetWorkFlowInstanceSubmitSelectItem(Guid workFlowInstanceUniqueId, string workFlowChartType)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowInstanceBLL.GetWorkFlowInstanceSubmitSelectItem(workFlowInstanceUniqueId, workFlowChartType));
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
        public HttpResponseMessage GetWorkFlowInstanceChart(Guid workFlowInstanceUniqueId,string workFlowChartType)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowInstanceBLL.GetWorkFlowInstanceChart(workFlowInstanceUniqueId, workFlowChartType));
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
