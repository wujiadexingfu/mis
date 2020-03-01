using MIS.Model.Account;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysUser;
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

        /// <summary>
        /// 查询人员 信息
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <returns></returns>
        PageData Query(SysUserParameter parameter);

        /// <summary>
        ///  根据UniqueId获取用户信息
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        SysUserInputForm GetUserByUniqueId(string uniqueId);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysUserInputForm inputForm);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysUserInputForm inputForm);

         /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(string uniqueId);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RequestResult ResetPassword(SysUserResetModel model);

        /// <summary>
        /// 获取所有人员信息
        /// </summary>
        /// <returns></returns>
        List<UserSelectItem> QueryUserSelectItemList();


        /// <summary>
        /// 根据角色的唯一编码找到已经选中的人员信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData QueryUserByRoleUniqueId(SysUserRoleParameter parameter);

        /// <summary>
        /// 根据角色的唯一编码查询到没有选中的人员信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData QueryNotSelectedUserByRoleUniqueId(SysUserRoleParameter parameter);
    }
}
