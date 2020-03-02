using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysAnnouncement
{
    public class SysAnnouncementInputForm
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public string Levels { get; set; }

        /// <summary>
        /// 选中的人员信息
        /// </summary>
        public List<string> SelectedUserUniqueId { get; set; }
    }
}
