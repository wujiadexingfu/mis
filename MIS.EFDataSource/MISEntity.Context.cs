﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MISEntities : DbContext
    {
        public MISEntities()
            : base("name=MISEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sys_Announcement> Sys_Announcement { get; set; }
        public virtual DbSet<Sys_AnnouncementUser> Sys_AnnouncementUser { get; set; }
        public virtual DbSet<Sys_Attachment> Sys_Attachment { get; set; }
        public virtual DbSet<Sys_Code> Sys_Code { get; set; }
        public virtual DbSet<Sys_ExceptionLog> Sys_ExceptionLog { get; set; }
        public virtual DbSet<Sys_File> Sys_File { get; set; }
        public virtual DbSet<Sys_Function> Sys_Function { get; set; }
        public virtual DbSet<Sys_ObjectAttachment> Sys_ObjectAttachment { get; set; }
        public virtual DbSet<Sys_Operation> Sys_Operation { get; set; }
        public virtual DbSet<Sys_OperationFunction> Sys_OperationFunction { get; set; }
        public virtual DbSet<Sys_Organization> Sys_Organization { get; set; }
        public virtual DbSet<Sys_Role> Sys_Role { get; set; }
        public virtual DbSet<Sys_RoleOperationFunction> Sys_RoleOperationFunction { get; set; }
        public virtual DbSet<Sys_User> Sys_User { get; set; }
        public virtual DbSet<Sys_UserRole> Sys_UserRole { get; set; }
        public virtual DbSet<view_OperationFunction> view_OperationFunction { get; set; }
        public virtual DbSet<view_UserRoleOperationFunction> view_UserRoleOperationFunction { get; set; }
    }
}
