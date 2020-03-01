using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysRole
{
   public class SysRoleOperationFunctionInputForm
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleUnqiueId { get; set; }

        /// <summary>
        /// 菜单和操作的唯一编码
        /// </summary>
        public List<string> OperationFunctionList{ get; set; }
    }
}
