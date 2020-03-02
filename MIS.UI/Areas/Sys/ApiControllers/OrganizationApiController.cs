using MIS.IBLL;
using MIS.Model.Sys.SysOrganization;
using MIS.Model.Tree;
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
    public class OrganizationApiController : ApiController
    {
        private ISysOrganizationBLL _sysOrganizationBLL;
        public OrganizationApiController(ISysOrganizationBLL sysOrganizationBLL)
        {
            _sysOrganizationBLL = sysOrganizationBLL;
        }


        /// <summary>
        /// 组织树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage InitTree()
        {
            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.InitTree());
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 获取部门组织树信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetOrganizationTreeNodes()
        {
            string parentUniqueId = "*";
            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.GetOrganizationTreeNodes(parentUniqueId));
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
        [HttpGet]
        [HttpPost]
        [OperationFilterAttribute(OperationType.Query)]
        public HttpResponseMessage Query(SysOrganizationParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 根据唯一编码获取组织信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemByUniqueId(string uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.GetItemByUniqueId(uniqueId));
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
        [HttpGet]
        [HttpPost]
        [OperationFilterAttribute(OperationType.Edit)]
        public HttpResponseMessage Edit(SysOrganizationInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.Edit(inputForm));
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
        [HttpGet]
        [HttpPost]
        [OperationFilterAttribute(OperationType.Add)]
        public HttpResponseMessage Add(SysOrganizationInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.Add(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [OperationFilterAttribute(OperationType.Delete)]
        public HttpResponseMessage Delete(string uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }




    }
}
