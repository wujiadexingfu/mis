using MIS.IBLL;
using MIS.Model.Result;
using MIS.Model.Sys.SysFunction;
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
    public class FunctionApiController : ApiController
    {
        private ISysFunctionBLL _sysFunctionBLL;

        public FunctionApiController(ISysFunctionBLL sysFunctionBLL)
        {
            _sysFunctionBLL = sysFunctionBLL;
        }

        /// <summary>
        /// 根据登录的用户获取到菜单数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetFunctionTreeByAccount()
        {
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.GetFunctionTreeByAccount()); 
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 根据操作的唯一编码获取到菜单数据
        /// </summary>
        /// <param name="operationUnqiueId"></param>
        /// <returns></returns>
        [HttpGet]
       [HttpPost]
        public HttpResponseMessage GetFunctionTreeByOperationUniqueId(Guid operationUnqiueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.GetFunctionTreeByOperationUniqueId(operationUnqiueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 根据唯一编码获取菜单信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemById(string Id)
        {

            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.GetItemByUniqueId(Id));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 修改组织信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Edit)]
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Edit(SysFunctionInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.Edit(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 新增组织信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Add)]
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Add(SysFunctionInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.Add(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Delete)]
        [HttpGet]
        public HttpResponseMessage Delete(string Id)
        {
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.Delete(Id));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage InitTree()
        {
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.InitTree());
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Query)]
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Query(SysFunctionParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


      /// <summary>
      /// 获取组织树
      /// </summary>
      /// <returns></returns>
        public HttpResponseMessage GetFunctionTreeNodes()
        {
            string parentUniqueId = "*";
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.GetFunctionTreeNodes(parentUniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 根据角色唯一编码获取菜单的操作信息
        /// </summary>
        /// <param name="operationUnqiueId"></param>
        /// <returns></returns>
        public HttpResponseMessage GetFunctionTreeByRoleUniqueId(Guid roleUnqiueId)
        {
          
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.GetFunctionTreeByRoleUniqueId(roleUnqiueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }
    }
}
