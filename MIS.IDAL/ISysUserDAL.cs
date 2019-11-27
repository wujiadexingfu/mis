using MIS.Model.Account;
using MIS.Utility.EnumUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************

** 类名称：  ISysUserDAL

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:23:02

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.IDAL
{
   public  interface ISysUserDAL
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Id">用户编号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        SystemEnums.LoginStatus Login(string Id, string password);

        /// <summary>
        /// 根据编号，获取登录人员信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Account GetAccountById(string Id);
    }
}
