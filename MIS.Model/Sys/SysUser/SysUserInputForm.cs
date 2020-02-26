using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.Sys.SysUser
{
   public class SysUserInputForm
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
        /// 地址  
        /// </summary> 
        public string Email { get; set; }

        /// <summary> 
        /// 生日  
        /// </summary> 
        public string BirthDay { get; set; }

        /// <summary> 
        /// 职称  
        /// </summary> 
        public string Title { get; set; }

        /// <summary> 
        /// 电话  
        /// </summary> 
        public string MobilePhone { get; set; }



        /// <summary> 
        /// 备注  
        /// </summary> 
        public string Remark { get; set; }

        /// <summary> 
        /// 开始有效日期  
        /// </summary> 
        public string StartExpiryDate { get; set; }

        /// <summary> 
        /// 结束有效日期  
        /// </summary> 
        public string EndExpiryDate { get; set; }

        /// <summary> 
        /// 是否允许登录  
        /// </summary> 
        public string  IsLogin { get; set; }

    }
}
