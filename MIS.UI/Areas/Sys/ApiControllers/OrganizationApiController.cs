using MIS.IBLL;
using MIS.Model.Sys.SysOrganization;
using MIS.Model.Tree;
using MIS.Utility.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

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
        [AllowAnonymous]
        public HttpResponseMessage InitTree()
        {
            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.InitTree());
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 根据唯一编码获取用户信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
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
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Query(SysOrganizationParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysOrganizationBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }
    }
}
