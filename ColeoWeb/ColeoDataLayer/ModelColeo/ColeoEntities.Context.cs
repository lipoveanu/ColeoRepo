﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ColeoEntities : DbContext
    {
        public ColeoEntities()
            : base("name=ColeoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueFile> IssueFiles { get; set; }
        public virtual DbSet<IssueLabel> IssueLabels { get; set; }
        public virtual DbSet<IssueStatu> IssueStatus { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatu> ProjectStatus { get; set; }
        public virtual DbSet<RelatedIssue> RelatedIssues { get; set; }
        public virtual DbSet<Reproducibility> Reproducibilities { get; set; }
        public virtual DbSet<Severity> Severities { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }
    }
}
