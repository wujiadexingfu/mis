using MIS.IBLL;
using MIS.Model.Sys.SysFile;
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
    public class SysFileApiController : ApiController
    {
        private ISysFileBLL _sysFileBLL;

        public SysFileApiController(ISysFileBLL sysFileBLL)
        {
            this._sysFileBLL = sysFileBLL;
        }


        /// <summary>
        /// 组织树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage InitTree()
        {
            var result = JosnNetHelper.ObjectToJson(_sysFileBLL.InitTree());
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



        /// <summary>
        /// 获取文件树的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public HttpResponseMessage GetSysFileTreeNodes()
        {
            Guid parentUniqueId = new Guid("00000000-0000-0000-0000-000000000000");
            var result = JosnNetHelper.ObjectToJson(_sysFileBLL.GetSysFileTreeNodes(parentUniqueId));
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
        [OperationFilterAttribute(OperationType.Query)]
        public HttpResponseMessage Query(SysFileParameter parameter)
        {
            var result = JosnNetHelper.ObjectToJson(_sysFileBLL.Query(parameter));
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
        public HttpResponseMessage GetItemByUniqueId(Guid uniqueId)
        {

            var result = JosnNetHelper.ObjectToJson(_sysFileBLL.GetItemByUniqueId(uniqueId));
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
        [OperationFilterAttribute(OperationType.Edit)]
        public HttpResponseMessage Edit(SysFileInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysFileBLL.Edit(inputForm));
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
        [OperationFilterAttribute(OperationType.Add)]
        public HttpResponseMessage Add(SysFileInputForm inputForm)
        {

            var result = JosnNetHelper.ObjectToJson(_sysFileBLL.Add(inputForm));
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
        [OperationFilterAttribute(OperationType.Delete)]
        public HttpResponseMessage Delete(Guid uniqueId)
        {
            var result = JosnNetHelper.ObjectToJson(_sysFileBLL.Delete(uniqueId));
            return new HttpResponseMessage()
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json"),
            };
        }



    }
}
