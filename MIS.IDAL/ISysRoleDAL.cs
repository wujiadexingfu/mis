using MIS.Model.Page;
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
        SysRoleInputForm GetItemByUniqueId(string uniqueId);


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
        RequestResult Delete(string uniqueId);

    }
}
