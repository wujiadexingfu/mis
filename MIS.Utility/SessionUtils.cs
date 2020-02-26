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
        /// <summary>
        /// 获取登录人员的Account信息
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 获取登录人员的唯一编码
        /// </summary>
        /// <returns></returns>
        public static string GetAccountUnqiueId()
        {
            var account = GetAccount();
            if (account != null)
            {
                return account.UniqueId;
            }
            else
            {
                return null;
            }
            
        }

    }
}
