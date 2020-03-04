using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************

** 类名称：  AccountFunctionOperation

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-25 07:19:50

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.Model.Account
{
   public  class AccountFunctionOperation
    {
       /// <summary>
       /// 菜单唯一编码
       /// </summary>
       public string FunctionId { get; set; }

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
       /// 操作Id
       /// </summary>
       public string  OperationId { get; set; }
    }
}
