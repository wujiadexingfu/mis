using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysRole
{
  public  class SysRoleUserInputForm
    {
        /// <summary>
        /// 角色的唯一编码
        /// </summary>
        public Guid RoleUniqueId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Guid> UserList { get; set; }
    }
}
