using MIS.Model.Account;
using MIS.Utility.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace MIS.UI.Filters
{
    public class GetOperationFilterAttribute: System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var account = (Account)HttpContext.Current.Session["Account"];
            var area = "";
            if (HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"] != null)
            {
                area = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString();
            }


            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();

            if (account != null)
            {
                var operations = account.AccountFunctionOperations.Where(x => x.Area == area && x.Controller == controller).Select(x => x.OperationId).ToList();
                string result = string.Join(",", operations.ToArray());
                //var result = JosnNetHelper.ObjectToJson(operations);
                filterContext.Controller.ViewBag.Actions = result;
            }

        


            base.OnActionExecuting(filterContext);
        }
    }
}