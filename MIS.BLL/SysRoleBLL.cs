﻿using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
   public class SysRoleBLL:ISysRoleBLL
    {
        public ISysRoleDAL _sysRoleDAL;
        public SysRoleBLL(ISysRoleDAL sysRoleDAL)
        {
            this._sysRoleDAL = sysRoleDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysRoleParameter parameter)
        {
            return _sysRoleDAL.Query(parameter);
        }

        /// <summary>
        /// 根据UniqueId获取角色信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public  SysRoleInputForm GetItemByUniqueId(Guid uniqueId)
        {
            return _sysRoleDAL.GetItemByUniqueId(uniqueId);
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
       public  RequestResult Add(SysRoleInputForm inputForm)
        {
            return _sysRoleDAL.Add(inputForm);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysRoleInputForm inputForm)
        {
            return _sysRoleDAL.Edit(inputForm);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
       public  RequestResult Delete(Guid uniqueId)
        {
            return _sysRoleDAL.Delete(uniqueId);
        }


        /// <summary>
        /// 添加用户菜单和操作权限的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult AddRoleOperationFunction(SysRoleOperationFunctionInputForm inputForm)
        {
            return _sysRoleDAL.AddRoleOperationFunction(inputForm);
        }

        /// <summary>
        /// 添加角色和用户的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
       public  RequestResult AddRoleUser(SysRoleUserInputForm inputForm)
        {
            return _sysRoleDAL.AddRoleUser(inputForm);
        }


        /// <summary>
        /// 删除角色用户的关联
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult DeleteRoleUser(Guid uniqueId)
        {
            return _sysRoleDAL.DeleteRoleUser(uniqueId);
        }

        /// <summary>
        /// 获取所有的角色信息
        /// </summary>
        /// <returns></returns>
        public List<SysRoleGrid> GetRoleList()
        {
            return _sysRoleDAL.GetRoleList();

        }

    }
}
