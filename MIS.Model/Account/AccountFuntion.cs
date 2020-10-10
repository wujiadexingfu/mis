using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************

** 类名称：  AccountFuntion

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 22:06:01

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.Model.Account
{
   public class AccountFuntion
    {
        /// <summary> 
        /// 编号  
        /// </summary> 
        [JsonProperty("id")]
        public string Id { get; set; }


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
        /// 图标  
        /// </summary> 
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary> 
        /// 排序  
        /// </summary> 
        public int? Sort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("title")]
        public string Description { get; set; }


        [JsonProperty("href")]
        public string Url{ get;set;}

        /// <summary>
        /// 菜单数据
        /// </summary>
        [JsonProperty("children")]
        public List<AccountFuntion> ChildAccountFuntion { get; set; }


       /// <summary>
       ///操作权限
       /// </summary>


        public AccountFuntion()
        {
            ChildAccountFuntion = new List<AccountFuntion>();

        }

    }
}
