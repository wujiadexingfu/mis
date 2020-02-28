using MIS.IBLL;
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
        public  SysRoleInputForm GetItemByUniqueId(string uniqueId)
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
       public  RequestResult Delete(string uniqueId)
        {
            return _sysRoleDAL.Delete(uniqueId);
        }

    }
}
