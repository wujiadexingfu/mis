using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysFunction
{
   public  class SysFunctionInputForm
    {
        /// <summary>
        /// 唯一编码
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public string Action { get; set; }


        /// <summary>
        /// 图案
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public string IsDisplay { get; set; }


    }
}
