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
    
    public partial class WorkFlow_Step
    {
        public System.Guid UniqueId { get; set; }
        public Nullable<System.Guid> WorkFlowChartUniqueId { get; set; }
        public string Name { get; set; }
        public string StepId { get; set; }
        public Nullable<double> StepLeft { get; set; }
        public Nullable<double> StepTop { get; set; }
        public string StepState { get; set; }
        public string AuditingType { get; set; }
        public Nullable<bool> IsBegin { get; set; }
        public string ActionUrl { get; set; }
        public Nullable<System.Guid> StepRole { get; set; }
        public string SaveFunction { get; set; }
        public Nullable<System.Guid> CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.Guid> ModifyUser { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string TableName { get; set; }
    }
}
