using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysFile
{
  public  class SysFileInputForm
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public Guid? ParentUniqueId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }

    }
}
