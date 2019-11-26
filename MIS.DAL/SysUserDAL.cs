using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.Utility.EnumUtility;
using MIS.EFDataSource;


/********************************************************************************

** 类名称：  SysUserDAL

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:21:04

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.DAL
{
  public    class SysUserDAL
    {
      public SystemEnums.LoginStatus Login(string Id, string password)
      {

          MISEntities db = new MISEntities();
            var result = SystemEnums.LoginStatus.NotExists;

            var user = db.Sys_User.Where(x => x.Id == Id).FirstOrDefault();
            if (user == null)  //用户不存在
            {
                result = SystemEnums.LoginStatus.NotExists;
                return result;
            }

            if (user.IsLogin) //不允许登录
            {
                result = SystemEnums.LoginStatus.NotLogin;
                return result;
            }

            if (user.StartExpiryDate!=null&&user.StartExpiryDate<DateTime.Now|| user.EndExpiryDate != null && user.EndExpiryDate >DateTime.Now)//时间超过有效期时间
            {
                result = SystemEnums.LoginStatus.ExpiryDateWrong;
                return result;
            }

            if (user.PassWord != password)  ///密码不正确
            {
                result = SystemEnums.LoginStatus.PasswordWrong;
                return result;
            }

            return SystemEnums.LoginStatus.Normal;  ///正常
      }
    }
}
