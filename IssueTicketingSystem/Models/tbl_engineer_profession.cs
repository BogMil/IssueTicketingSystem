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
    
    public partial class tbl_engineer_profession
    {
        public int Id { get; set; }
        public int IdTypeOfComplain { get; set; }
        public int IdServiceEngineer { get; set; }
    
        public virtual tbl_service_engineer tbl_service_engineer { get; set; }
        public virtual tbl_type_of_complain tbl_type_of_complain { get; set; }
    }
}