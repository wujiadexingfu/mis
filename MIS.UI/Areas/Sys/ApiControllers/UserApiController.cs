using MIS.IBLL;
using MIS.Model.Sys.SysUser;
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


        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Query(SysUserParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysUserBLL.Query(parameter));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm">修改参数</param>
        /// <returns></returns>

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Edit(SysUserInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysUserBLL.Edit(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm">新增参数</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Add(SysUserInputForm inputForm)
        {
            var result = JosnNetHelper.ObjectToJson(_sysUserBLL.Add(inputForm));
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
        public HttpResponseMessage GetUserByUniqueId(string  uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysUserBLL.GetUserByUniqueId(uniqueId));
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
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Delete(string uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysUserBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


    /// <summary>
    /// 重新设置密码
    /// </summary>
    /// <param name="selected">选择的唯一编码</param>
    /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage ResetPassword(SysUserResetModel selected)
        {
            var result = JosnNetHelper.ObjectToJson(_sysUserBLL.ResetPassword(selected));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



    }
}
