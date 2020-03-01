using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysCode
{
   public  class SysCodeInputForm
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// 显示值
        /// </summary>
        public string CodeText { get; set; }

        /// <summary>
        /// 值
        /// </summary>

        public string CodeValue { get; set; }


        /// <summary>
        /// 父节点
        /// </summary>
        public string ParentUniqueId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
    }
}
