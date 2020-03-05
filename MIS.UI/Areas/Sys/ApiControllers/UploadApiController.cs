using MIS.IBLL;
using MIS.Model.Sys;
using MIS.Utility.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace MIS.UI.Areas.Sys.ApiControllers
{
    public class UploadApiController : ApiController
    {
        private ISysAttachmentBLL _sysAttachmentBLL;

        public UploadApiController(ISysAttachmentBLL sysAttachmentBLL)
        {
            this._sysAttachmentBLL = sysAttachmentBLL;
        }

        /// <summary>
        /// 上传文件，保存记录到数据库中
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {

            HttpRequest request = HttpContext.Current.Request;
            var files = request.Files;
            var result = JosnNetHelper.ObjectToJson(_sysAttachmentBLL.Add(files[0]));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Edit(SysAttachmentInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysAttachmentBLL.Edit(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage Delete(Guid uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysAttachmentBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemByUniqueId(Guid uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysAttachmentBLL.GetItemByUnqiueId(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



    }
}
