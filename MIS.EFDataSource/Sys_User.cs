//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MIS.EFDataSource
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sys_User
    {
        public string UniqueId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string OrganizationUniqueId { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Title { get; set; }
        public string MobilePhone { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreateUser { get; set; }
        public string ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> StartExpiryDate { get; set; }
        public Nullable<System.DateTime> EndExpiryDate { get; set; }
        public bool IsLogin { get; set; }
    }
}
