using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysUser
{
   public class SysOrganizationUserParameter
    {
        public List<Guid> SelectedUserList { get; set; }

        public SysOrganizationUserParameter()
        {
            SelectedUserList = new List<Guid>();
        }
    }
}
