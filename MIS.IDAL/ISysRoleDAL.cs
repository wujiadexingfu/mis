﻿using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
   public interface ISysRoleDAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(SysRoleParameter parameter);


         /// <summary>
        /// 根据UniqueId获取角色信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        SysRoleInputForm GetItemByUniqueId(Guid uniqueId);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysRoleInputForm inputForm);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysRoleInputForm inputForm);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(Guid uniqueId);

        /// <summary>
        /// 添加用户菜单和操作权限的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult AddRoleOperationFunction(SysRoleOperationFunctionInputForm inputForm);

        /// <summary>
        /// 添加角色和用户的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult AddRoleUser(SysRoleUserInputForm inputForm);


        /// <summary>
        /// 删除角色用户的关联
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult DeleteRoleUser(Guid uniqueId);


        /// <summary>
        /// 获取所有的角色信息
        /// </summary>
        /// <returns></returns>
        List<SysRoleGrid> GetRoleList();
    }
}
