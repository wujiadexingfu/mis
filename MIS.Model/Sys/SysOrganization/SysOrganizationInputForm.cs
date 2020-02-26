using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysOrganization
{
  public  class SysOrganizationInputForm
    {
        /// <summary> 
        /// 唯一编码  
        /// </summary> 
        public string UniqueId { get; set; }

        /// <summary> 
        /// 编号  
        /// </summary> 
        public string Id { get; set; }

        /// <summary> 
        /// 名称  
        /// </summary> 
        public string Name { get; set; }

        /// <summary> 
        /// 图标  
        /// </summary> 
        public string Icon { get; set; }

        /// <summary> 
        /// 父节点  
        /// </summary> 
        public string ParentUniqueId { get; set; }

        /// <summary> 
        /// 负责人  
        /// </summary> 
        public string ManagerUniqueId { get; set; }

        /// <summary> 
        ///   
        /// </summary> 
        public int? Seq { get; set; }

    }
}
