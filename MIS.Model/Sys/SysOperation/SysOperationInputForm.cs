using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysOperation
{
   public  class SysOperationInputForm
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
