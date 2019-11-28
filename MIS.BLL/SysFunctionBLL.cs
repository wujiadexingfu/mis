using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Account;
using MIS.Model.Result;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
   public class SysFunctionBLL: ISysFunctionBLL
    {
        private ISysFunctionDAL _sysFunctionDAL;
        public SysFunctionBLL(ISysFunctionDAL sysFunctionDAL)
        {
            _sysFunctionDAL = sysFunctionDAL;
        }

        public RequestResult GetFunctionTreeByAccount()
        {
            // var accountId = ((Account)System.Web.HttpContext.Current.Session[Constant.Account]).UniqueId;

            var accountId = "5BE2DAD8-BA8C-480C-95FD-FD5CA26BDE28";

            return _sysFunctionDAL.GetFunctionTreeByAccount(accountId);
        }


    }
}
