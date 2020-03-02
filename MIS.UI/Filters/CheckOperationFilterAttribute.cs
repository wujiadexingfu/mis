using MIS.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.UI.Filters
{
    public class CheckOperationFilterAttribute
    {

        private static bool CheckOperation(OperationType operationType)
        {
            var account = (Account)HttpContext.Current.Session["Account"];
            var area = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString();
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();

            if (account.AccountFunctionOperations.Any(x => x.Controller == controller && x.Area == area && x.OperationId == operationType.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckQuery()
        {
            return CheckOperation(OperationType.Query);
        }

        public static bool CheckAdd()
        {
            return CheckOperation(OperationType.Add);
        }

       
    }
}