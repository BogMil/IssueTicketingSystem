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
    
    public partial class tbl_region
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_region()
        {
            this.tbl_location = new HashSet<tbl_location>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdState { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_location> tbl_location { get; set; }
        public virtual tbl_state tbl_state { get; set; }
    }
}
