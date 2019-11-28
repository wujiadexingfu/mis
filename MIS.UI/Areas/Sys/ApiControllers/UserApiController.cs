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
    public class UserApiController : ApiController
    {
        private ISysUserBLL _sysUserBLL;
        public UserApiController(ISysUserBLL sysUserBLL)
        {
            _sysUserBLL = sysUserBLL;
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage Login(string Id,string password)
        {
            var result = JosnNetHelper.ObjectToJson(_sysUserBLL.Login(Id,password));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


    }
}
