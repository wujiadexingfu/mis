using MIS.Model.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysUser
{
   public  class SysUserRoleParameter:BaseParameter
    {
        /// <summary>
        /// 角色的唯一编码
        /// </summary>
        public string RoleUniqueId { get; set; }


        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }
    }
}
