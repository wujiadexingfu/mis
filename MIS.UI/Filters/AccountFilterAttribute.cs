using MIS.Model.Account;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace MIS.UI.Filters
{
    public class AccountFilterAttribute: ActionFilterAttribute
    {
        /// <summary>
        /// 检验Session是否存在，不存在则跳转到登录界面
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var account = (Account)HttpContext.Current.Session[Constant.Account];
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();
            var action= HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
            
           


            if (account == null) //如果session 为空
            {
                if (controller != "Home" && action != "Login")
                {

                    var routeValue = new RouteValueDictionary {
                        { "Controller", "Home"},
                        { "Action", "Login"},
                        { "Area",""}
                       };
                     filterContext.Result = new RedirectToRouteResult(routeValue);
                }
               
            }
            base.OnActionExecuting(filterContext);
        }

    }
}