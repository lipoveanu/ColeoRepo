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
    
    public partial class Issue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Issue()
        {
            this.Histories = new HashSet<History>();
            this.IssueFiles = new HashSet<IssueFile>();
            this.IssueLabels = new HashSet<IssueLabel>();
            this.Notes = new HashSet<Note>();
            this.RelatedIssues = new HashSet<RelatedIssue>();
            this.RelatedIssues1 = new HashSet<RelatedIssue>();
        }
    
        public int Id { get; set; }
        public int IdProject { get; set; }
        public string IdUserReporter { get; set; }
        public string IdUserAssigned { get; set; }
        public int IdStatus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
        public string StepsToReproduce { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateLastUpdate { get; set; }
        public string Platform { get; set; }
        public string Os { get; set; }
        public string OsVersion { get; set; }
        public int IdPriority { get; set; }
        public int IdSeverity { get; set; }
        public int IdReproducibility { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> Histories { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual Reproducibility Reproducibility { get; set; }
        public virtual Severity Severity { get; set; }
        public virtual IssueStatus IssueStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueFile> IssueFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueLabel> IssueLabels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Note> Notes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelatedIssue> RelatedIssues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelatedIssue> RelatedIssues1 { get; set; }
    }
}
