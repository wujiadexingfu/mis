using MIS.IBLL;
using MIS.Model.Sys.SysCode;
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
    public class SysCodeApiController : ApiController
    {

        private ISysCodeBLL _sysCodeBLL;
        public SysCodeApiController(ISysCodeBLL sysCodeBLL)
        {
            _sysCodeBLL = sysCodeBLL;
        }


        /// <summary>
        /// 组织树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage InitTree()
        {
            var result = JosnNetHelper.ObjectToJson(_sysCodeBLL.InitTree());
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

      
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetSysCodeTreeNodes()
        {
            string parentUniqueId = "*";
            var result = JosnNetHelper.ObjectToJson(_sysCodeBLL.GetSysCodeTreeNodes(parentUniqueId));
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
        public HttpResponseMessage Query(SysCodeParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysCodeBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 根据唯一编码获参数信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemByUniqueId(string uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysCodeBLL.GetItemByUniqueId(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Edit(SysCodeInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysCodeBLL.Edit(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Add(SysCodeInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysCodeBLL.Add(inputForm));
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
        public HttpResponseMessage Delete(string uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysCodeBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

    }
}
