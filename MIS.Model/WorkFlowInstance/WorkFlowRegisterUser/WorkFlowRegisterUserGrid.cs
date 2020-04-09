using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlowInstance.WorkFlowRegisterUser
{
    public class WorkFlowRegisterUserGrid
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

        /// <summary>
        /// 生日
        /// </summary>
        public string  BirthDay { get; set; }

        /// <summary>
        /// 备注
        /// </summary>

        public string Remark { get; set; }


        /// <summary>
        /// 流程状态
        /// </summary>
        public string WorkFlowStep { get; set; }


        /// <summary>
        /// 流程实例的唯一编码
        /// </summary>
        public Guid? WorkFlowInstanceUniqueId { get; set; }
    }
}
