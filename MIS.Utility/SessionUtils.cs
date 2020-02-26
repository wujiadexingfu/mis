using MIS.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility
{
   public   class SessionUtils
    {
        public static Account GetAccount()
        {

            if (System.Web.HttpContext.Current.Session[Constant.Account] != null)
            {
                return (Account)System.Web.HttpContext.Current.Session[Constant.Account];
            }
            else
            {
                return null;
            }
        }


        public static string GetAccountUnqiueId()
        {
            return GetAccount().UniqueId;
        }

    }
}
