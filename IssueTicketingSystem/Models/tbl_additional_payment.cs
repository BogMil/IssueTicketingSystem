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
    
    public partial class tbl_additional_payment
    {
        public int Id { get; set; }
        public Nullable<int> IdVendor { get; set; }
        public int IdIssue { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        public int IdPaymentStatus { get; set; }
    
        public virtual tbl_complain_issue tbl_complain_issue { get; set; }
        public virtual tbl_payment_status tbl_payment_status { get; set; }
        public virtual tbl_vendor tbl_vendor { get; set; }
    }
}
