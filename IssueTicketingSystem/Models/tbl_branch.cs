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
    
    public partial class tbl_branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_branch()
        {
            this.tbl_company_branch = new HashSet<tbl_company_branch>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdLocation { get; set; }
    
        public virtual tbl_location tbl_location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_company_branch> tbl_company_branch { get; set; }
    }
}
