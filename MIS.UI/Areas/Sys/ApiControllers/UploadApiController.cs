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

        [HttpGet]
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {

            HttpRequest request = HttpContext.Current.Request;
            var files = request.Files;



            for (int i = 0; i < files.Count; i++)
            {
                files[i].SaveAs("");
               var file1= files[i].FileName;
            }

            


            //var result = JosnNetHelper.ObjectToJson(_sysAnnouncementBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent("", Encoding.UTF8, "application/json"),
            };
        }
    }
}
