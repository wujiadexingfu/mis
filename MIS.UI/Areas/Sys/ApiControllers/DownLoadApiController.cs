using MIS.IBLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace MIS.UI.Areas.Sys.ApiControllers
{
    public class DownLoadApiController : ApiController
    {
        private ISysAttachmentBLL _sysAttachmentBLL;

        public DownLoadApiController(ISysAttachmentBLL sysAttachmentBLL)
        {
            this._sysAttachmentBLL = sysAttachmentBLL;
        }


      
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage DownLoadFile(Guid uniqueId)
        {

            var attachment = _sysAttachmentBLL.GetItemByUnqiueId(uniqueId);

            FileStream stream = new FileStream(attachment.Path, FileMode.Open);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = HttpUtility.UrlEncode(attachment.FullFileName)
            };
            response.Headers.Add("Access-Control-Expose-Headers", "FileName");
            response.Headers.Add("FileName", HttpUtility.UrlEncode(attachment.FullFileName));
            return response;



          
        }



    }
}
