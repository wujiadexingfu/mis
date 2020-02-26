using MIS.IBLL;
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
    public class FunctionApiController : ApiController
    {
        private ISysFunctionBLL _sysFunctionBLL;

        public FunctionApiController(ISysFunctionBLL sysFunctionBLL)
        {
            _sysFunctionBLL = sysFunctionBLL;
        }

        [AcceptVerbs("get", "post")]
        [AllowAnonymous]
        public HttpResponseMessage GetFunctionTreeByAccount()
        {
            var result = JosnNetHelper.ObjectToJson(_sysFunctionBLL.GetFunctionTreeByAccount()); 
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

       
    }
}
