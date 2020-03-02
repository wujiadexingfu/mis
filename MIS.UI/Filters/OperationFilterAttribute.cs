using MIS.Model.Account;
using MIS.Model.Result;
using MIS.Utility;
using MIS.Utility.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.UI.Filters
{
    /// <summary>
    /// WebApi权限过滤器
    /// </summary>
    public class OperationFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        private OperationType _operationType { get; set; }
        public OperationFilterAttribute(OperationType operationType)
        {
            this._operationType = operationType;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (!CheckOperation(actionContext))
            {
                RequestResult requestResult = new RequestResult();
                requestResult.ReturnFailedMessage("没有权限");
                var result = JosnNetHelper.ObjectToJson(requestResult);
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage { Content = new StringContent(result, Encoding.GetEncoding("UTF-8"), "application/json") };
                actionContext.Response = httpResponseMessage;
            }

            base.OnActionExecuting(actionContext);

        }


        /// <summary>
        /// 判断权限
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        public bool CheckOperation(HttpActionContext actionContext)
        {
            var account =(Account) HttpContext.Current.Session[Constant.Account];
            var area = actionContext.RequestContext.RouteData.Values["area"].ToString();
            var controller = actionContext.RequestContext.RouteData.Values["controller"].ToString();

            if (account.AccountFunctionOperations.Any(x => x.Controller == controller && x.Area == area && x.OperationId == _operationType.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }





        


            return false;
        }


    }
}