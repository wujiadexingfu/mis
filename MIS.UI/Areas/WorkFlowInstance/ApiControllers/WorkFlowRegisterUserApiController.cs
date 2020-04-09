using MIS.IBLL;
using MIS.Model.WorkFlowInstance.WorkFlowRegisterUser;
using MIS.UI.Filters;
using MIS.Utility.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.UI.Areas.WorkFlowInstance.ApiControllers
{
    public class WorkFlowRegisterUserApiController : ApiController
    {
        private IWorkFlowRegisterUserBLL _workFlowRegisterUserBLL;
        public WorkFlowRegisterUserApiController(IWorkFlowRegisterUserBLL workFlowRegisterUserBLL)
        {
            _workFlowRegisterUserBLL = workFlowRegisterUserBLL;
        }

   
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Query)]
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Query(WorkFlowRegisterUserParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_workFlowRegisterUserBLL.Query(parameter));
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
        public HttpResponseMessage Edit(WorkFlowRegisterUserInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowRegisterUserBLL.Edit(inputForm));
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
        [OperationFilterAttribute(OperationType.Add)]
        [HttpPost]
        public HttpResponseMessage Add(WorkFlowRegisterUserInputForm inputForm)
        {
            var result = JosnNetHelper.ObjectToJson(_workFlowRegisterUserBLL.Add(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 根据唯一编码获取信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemByUniqueId(Guid workFlowInstanceUniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_workFlowRegisterUserBLL.GetItemByUniqueId(workFlowInstanceUniqueId));
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
        [OperationFilterAttribute(OperationType.Delete)]
        [HttpGet]
        public HttpResponseMessage Delete(Guid uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_workFlowRegisterUserBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }
    }
}
