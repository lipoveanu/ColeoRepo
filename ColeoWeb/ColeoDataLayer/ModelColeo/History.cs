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
    
    public partial class History
    {
        public int Id { get; set; }
        public System.DateTime DateModified { get; set; }
        public string IdUser { get; set; }
        public int IdIssue { get; set; }
        public string Field { get; set; }
        public string Change { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Issue Issue { get; set; }
    }
}