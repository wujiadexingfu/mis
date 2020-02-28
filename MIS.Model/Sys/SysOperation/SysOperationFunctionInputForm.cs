using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysOperation
{
  public  class SysOperationFunctionInputForm
    {
        /// <summary>
        /// 操作的唯一编码
        /// </summary>
        public string OperationUnqiueId { get; set; }

        /// <summary>
        /// 选中的菜单选项
        /// </summary>
        public List<string> FunctionList { get; set; }

        public SysOperationFunctionInputForm()
        {
            FunctionList = new List<string>();
        }
    }
}
