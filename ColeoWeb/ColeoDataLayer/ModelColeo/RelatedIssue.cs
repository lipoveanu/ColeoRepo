//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ColeoDataLayer.ModelColeo
{
    using System;
    using System.Collections.Generic;
    
    public partial class RelatedIssue
    {
        public int Id { get; set; }
        public int IdIssue { get; set; }
        public int IdIssueRelated { get; set; }
    
        public virtual Issue Issue { get; set; }
        public virtual Issue Issue1 { get; set; }
    }
}