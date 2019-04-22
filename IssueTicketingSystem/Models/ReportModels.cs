using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PagedList;

namespace IssueTicketingSystem.Models
{
    public class MIS
    {
        public string RegionalAdmin { get; set; }
        public string Company { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string TypeOfComplain { get; set; }
        public string RequestedDate { get; set; }
        public string Complain { get; set; }
        public string Issue { get; set; }
        public string IssueDescription { get; set; }
        public string CloseDate { get; set; }
        public string Aging { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public string Vendor { get; set; }
        public string IFSC { get; set; }
        public string Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string Engineer { get; set; }
    }

    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<tbl_vendor_payment, MIS>()
                .ForMember(d => d.RegionalAdmin, o => o.MapFrom(s => "Region Admin"))
                .ForMember(d => d.Company, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_company.Name))
                .ForMember(d => d.State,
                    o => o.MapFrom(s =>
                        s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.tbl_state.Name))
                .ForMember(d => d.Region,
                    o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name))
                .ForMember(d => d.Region,
                    o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name))
                .ForMember(d => d.Location,
                    o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.Name))
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.Name))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.Address))
                .ForMember(d => d.TypeOfComplain, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_type_of_complain.Name))
                .ForMember(d => d.RequestedDate, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.RequstedDate.GetDateString()))
                .ForMember(d => d.Complain, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.Remark))
                .ForMember(d => d.Issue, o => o.MapFrom(s => s.tbl_complain_issue.Subject))
                .ForMember(d => d.IssueDescription, o => o.MapFrom(s => s.tbl_complain_issue.Description))
                .ForMember(d => d.CloseDate, o => o.MapFrom(s => "closed date"))
                .ForMember(d => d.Aging, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.Aging))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.tbl_complain_issue.tbl_issue_status.Name))
                .ForMember(d => d.Remark, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.Remark))
                .ForMember(d => d.Vendor, o => o.MapFrom(s => s.tbl_vendor.Name))
                .ForMember(d => d.IFSC, o => o.MapFrom(s => s.tbl_vendor.IFSC))
                .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount))
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => s.tbl_payment_status.Name));

            CreateMap<tbl_assigned_service_engineer_to_issue, MIS>()
                .ForMember(d => d.RegionalAdmin, o => o.MapFrom(s => "Region Admin"))
                .ForMember(d => d.Company, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_company.Name))
                .ForMember(d => d.State,
                    o => o.MapFrom(s =>
                        s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.tbl_state.Name))
                .ForMember(d => d.Region,
                    o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name))
                .ForMember(d => d.Region,
                    o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name))
                .ForMember(d => d.Location,
                    o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.Name))
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.tbl_branch.Name))
                .ForMember(d => d.Address, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_company_branch.Address))
                .ForMember(d => d.TypeOfComplain, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.tbl_type_of_complain.Name))
                .ForMember(d => d.RequestedDate, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.RequstedDate.GetDateString()))
                .ForMember(d => d.Complain, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.Remark))
                .ForMember(d => d.Issue, o => o.MapFrom(s => s.tbl_complain_issue.Subject))
                .ForMember(d => d.IssueDescription, o => o.MapFrom(s => s.tbl_complain_issue.Description))
                .ForMember(d => d.CloseDate, o => o.MapFrom(s => "closed date"))
                .ForMember(d => d.Aging, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.Aging))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.tbl_complain_issue.tbl_issue_status.Name))
                .ForMember(d => d.Remark, o => o.MapFrom(s => s.tbl_complain_issue.tbl_complain.Remark))
                .ForMember(d => d.Vendor, o => o.MapFrom(s => s.tbl_complain_issue.tbl_vendor_payment.Where(d=>d.IdVendor==s.tbl_service_engineer.IdVendor).Select(f=>f.tbl_vendor.Name).ToString()))
                .ForMember(d => d.IFSC, o => o.MapFrom(s => "-"))
                .ForMember(d => d.Amount, o => o.MapFrom(s => "-"))
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => "-"));

            CreateMap<PagedList<tbl_replacement>, StaticPagedList<ReplacementQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_replacement, ReplacementQueryDto>>();
        }
    }
}