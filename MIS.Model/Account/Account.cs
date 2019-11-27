using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************

** 类名称：  Account

** 描述：登录账户

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 21:50:02

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.Model.Account
{
   public   class Account
    {
       /// <summary>
       /// 唯一编码
       /// </summary>
       public string UniqueId { get; set; }


        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

       /// <summary>
       /// 名称
       /// </summary>
       public string Name { get; set; }

       /// <summary>
       /// 组织
       /// </summary>
       public string OrganizationUniqueId { get; set; }
       /// <summary>
       /// 职称
       /// </summary>
       public string Title { get; set; }
    }
}
