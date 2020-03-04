using MIS.IBLL;
using MIS.Model.Sys.SysRole;
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
    public class RoleApiController : ApiController
    {
        private ISysRoleBLL _sysRoleBLL;
        public RoleApiController(ISysRoleBLL sysRoleBLL)
        {
            _sysRoleBLL = sysRoleBLL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [OperationFilterAttribute(OperationType.Query)]
        public HttpResponseMessage Query(SysRoleParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.Query(parameter));
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
        [OperationFilterAttribute(OperationType.Edit)]
        [HttpPost]
        public HttpResponseMessage Edit(SysRoleInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.Edit(inputForm));
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
        [OperationFilterAttribute(OperationType.Add)]
        public HttpResponseMessage Add(SysRoleInputForm inputForm)
        {
            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.Add(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 根据唯一编码获取角色信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetItemByUniqueId(Guid uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.GetItemByUniqueId(uniqueId));
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
        [HttpGet]
        [OperationFilterAttribute(OperationType.Delete)]
        public HttpResponseMessage Delete(Guid uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        ///  添加用户菜单和操作权限的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage AddRoleOperationFunction(SysRoleOperationFunctionInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.AddRoleOperationFunction(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }

        /// <summary>
        /// 添加角色和用户的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage AddRoleUser(SysRoleUserInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.AddRoleUser(inputForm));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }


        /// <summary>
        /// 删除角色用户的关联
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage DeleteRoleUser(Guid uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysRoleBLL.DeleteRoleUser(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



    }
}
