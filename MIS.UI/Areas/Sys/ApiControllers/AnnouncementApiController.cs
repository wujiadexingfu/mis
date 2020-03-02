using MIS.IBLL;
using MIS.Model.Sys.SysAnnouncement;
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
    public class AnnouncementApiController : ApiController
    {
        private ISysAnnouncementBLL _sysAnnouncementBLL;

        public AnnouncementApiController(ISysAnnouncementBLL sysAnnouncementBLL)
        {
            _sysAnnouncementBLL = sysAnnouncementBLL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Query)]
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Query(SysAnnouncementParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysAnnouncementBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm">修改公告</param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Edit)]
        [HttpPost]
        public HttpResponseMessage Edit(SysAnnouncementInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysAnnouncementBLL.Edit(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm">新增公告</param>
        /// <returns></returns>
        [OperationFilterAttribute(OperationType.Add)]
        [HttpPost]
        public HttpResponseMessage Add(SysAnnouncementInputForm inputForm)
        {
            var result = JosnNetHelper.ObjectToJson(_sysAnnouncementBLL.Add(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 根据唯一编码获取公告信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemByUniqueId(string uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysAnnouncementBLL.GetItemByUniqueId(uniqueId));
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
        public HttpResponseMessage Delete(string uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysAnnouncementBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

    }
}
