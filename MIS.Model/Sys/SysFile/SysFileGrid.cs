using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysFile
{
   public  class SysFileGrid
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 上传人员
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public string CreateTime { get; set; }


        /// <summary>
        /// 对象的唯一编码
        /// </summary>
        public Guid? ObjectUniqueId { get; set; }
    }
}
