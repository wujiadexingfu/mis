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
    
    public partial class view_workflowStepLine
    {
        public System.Guid LineUniqueId { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> WorkFlowChartUniqueId { get; set; }
        public System.Guid FromStepUniqueId { get; set; }
        public string FromStepName { get; set; }
        public System.Guid ToStepUniqueId { get; set; }
        public string ToStepName { get; set; }
    }
}