﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IssueTicketingSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IssueTicketingSystemEntities : DbContext
    {
        public IssueTicketingSystemEntities()
            : base("name=IssueTicketingSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_account> tbl_account { get; set; }
        public virtual DbSet<tbl_assigned_service_engineer_to_issue> tbl_assigned_service_engineer_to_issue { get; set; }
        public virtual DbSet<tbl_branch> tbl_branch { get; set; }
        public virtual DbSet<tbl_company> tbl_company { get; set; }
        public virtual DbSet<tbl_company_branch> tbl_company_branch { get; set; }
        public virtual DbSet<tbl_complain> tbl_complain { get; set; }
        public virtual DbSet<tbl_complain_issue> tbl_complain_issue { get; set; }
        public virtual DbSet<tbl_engineer_profession> tbl_engineer_profession { get; set; }
        public virtual DbSet<tbl_issue_status> tbl_issue_status { get; set; }
        public virtual DbSet<tbl_location> tbl_location { get; set; }
        public virtual DbSet<tbl_part> tbl_part { get; set; }
        public virtual DbSet<tbl_part_status> tbl_part_status { get; set; }
        public virtual DbSet<tbl_part_types> tbl_part_types { get; set; }
        public virtual DbSet<tbl_payment_status> tbl_payment_status { get; set; }
        public virtual DbSet<tbl_region> tbl_region { get; set; }
        public virtual DbSet<tbl_repairment> tbl_repairment { get; set; }
        public virtual DbSet<tbl_replacement> tbl_replacement { get; set; }
        public virtual DbSet<tbl_roles> tbl_roles { get; set; }
        public virtual DbSet<tbl_service_engineer> tbl_service_engineer { get; set; }
        public virtual DbSet<tbl_state> tbl_state { get; set; }
        public virtual DbSet<tbl_type_of_complain> tbl_type_of_complain { get; set; }
        public virtual DbSet<tbl_unit> tbl_unit { get; set; }
        public virtual DbSet<tbl_vendor> tbl_vendor { get; set; }
        public virtual DbSet<tbl_vendor_payment> tbl_vendor_payment { get; set; }
    }
}
