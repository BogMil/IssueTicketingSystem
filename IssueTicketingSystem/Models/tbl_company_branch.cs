//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tbl_company_branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_company_branch()
        {
            this.tbl_complain = new HashSet<tbl_complain>();
        }
    
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int IdBranch { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public bool Active { get; set; }
    
        public virtual tbl_branch tbl_branch { get; set; }
        public virtual tbl_company tbl_company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_complain> tbl_complain { get; set; }
    }
}
