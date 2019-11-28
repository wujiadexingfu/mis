using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Account;
using MIS.Model.Result;
using MIS.Utility;
using MIS.Utility.EnumUtility;

/********************************************************************************

** 类名称：  SysUserBLL

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:22:04

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.BLL
{
    public  class SysUserBLL: ISysUserBLL
    {
        ISysUserDAL _sysUserDAL;
        public SysUserBLL(ISysUserDAL sysUserDAL)
        {
            _sysUserDAL = sysUserDAL;
        }

        /// <summary>
        /// 登录，
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public RequestResult Login(string Id, string password)
        {
            RequestResult result = new RequestResult();
            var loginStatus= _sysUserDAL.Login(Id, password);

            if (loginStatus == SystemEnums.LoginStatus.NotExists)
            {
                result.ReturnFailedMessage("该用户尚未注册！");
            }
            else if (loginStatus == SystemEnums.LoginStatus.NotLogin)
            {
                result.ReturnFailedMessage("该用户没有登录权限！");
            }
            else if (loginStatus == SystemEnums.LoginStatus.PasswordWrong)
            {
                result.ReturnFailedMessage("密码错误！");
            }
            else if (loginStatus == SystemEnums.LoginStatus.ExpiryDateWrong)
            {
                result.ReturnFailedMessage("有效期超期！");
            }
            else {
                var account= _sysUserDAL.GetAccountById(Id);
                System.Web.HttpContext.Current.Session[Constant.Account] = account;  //将用户数据放在Session中
                result.ReturnData(account);

            }
            return result;
        }

    }
}
