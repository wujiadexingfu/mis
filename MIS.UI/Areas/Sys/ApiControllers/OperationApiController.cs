using MIS.IBLL;
using MIS.Model.Sys.SysOperation;
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

namespace MIS.UI.Areas.Sys.ApiControllers
{
    public class OperationApiController : ApiController
    {
        private ISysOperationBLL _sysOperationBLL;
        public OperationApiController(ISysOperationBLL sysOperationBLL)
        {
            _sysOperationBLL = sysOperationBLL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [OperationFilterAttribute(OperationType.Query)]
        public HttpResponseMessage Query(SysOperationParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysOperationBLL.Query(parameter));
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
        public HttpResponseMessage Edit(SysOperationInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysOperationBLL.Edit(inputForm));
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
        public HttpResponseMessage Add(SysOperationInputForm inputForm)
        {
            var result = JosnNetHelper.ObjectToJson(_sysOperationBLL.Add(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 根据唯一编码获取操作信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetOperationByUniqueId(string uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysOperationBLL.GetOperationByUniqueId(uniqueId));
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
        public HttpResponseMessage Delete(string uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysOperationBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



        /// <summary>
        ///  新增操作和菜单的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]

        public HttpResponseMessage AddOperationFunction(SysOperationFunctionInputForm inputForm)
        {
            var result = JosnNetHelper.ObjectToJson(_sysOperationBLL.AddOperationFunction(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


    }
}
