using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys
{
   public class SysAttachmentInputForm
    {
        public Guid UniqueId { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
       public int FileSize { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 保存文件的路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// 关联对象的唯一编码
        /// </summary>
        public Guid? AttachmentUniqueId { get; set; }


        /// <summary>
        /// 唯一编码
        /// </summary>
        public Guid? ObjectUniqueId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        public string FullFileName
        {
            get {
                return FileName + FileExtension;
            }
        }

    }
}
