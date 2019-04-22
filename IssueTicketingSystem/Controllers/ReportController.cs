using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ExpressionBuilder.Operations;
using IssueTicketingSystem.Models;
using Microsoft.Ajax.Utilities;

namespace IssueTicketingSystem.Controllers
{
    public class ReportController : Controller
    {
        private IMapper _mapper;
        public ReportController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ActionResult MIS()
        {
            return View();
        }
        public ActionResult MISData()
        {
            var db = new IssueTicketingSystemEntities();

            var complainIssuesOfSelectedPeriod = db.tbl_complain.Where(q =>
                    q.RequstedDate.Month == DateTime.Now.Month && q.RequstedDate.Year == DateTime.Now.Year)
                .SelectMany(w => w.tbl_complain_issue);

            List<MIS> asd=new List<MIS>();

            foreach (var complainIssue in complainIssuesOfSelectedPeriod)
            {

                var assignedVendors = complainIssue.tbl_assigned_service_engineer_to_issue.Select(s => s.tbl_service_engineer.IdVendor).Where(d=>d!=null).Distinct().ToList();

                var payedVendors = complainIssue.tbl_vendor_payment.Where(d=>d.IdVendor!=null).Select(s => s.IdVendor).ToList();

                var unpayedVendors= assignedVendors.Where(s=>!payedVendors.Contains(s)).ToList();

                foreach (var vendor in payedVendors)
                {
                    var engineers = complainIssue.tbl_assigned_service_engineer_to_issue.Where(s=>s.tbl_service_engineer.IdVendor==vendor);

                    foreach (var engineer in engineers)
                    {
                        var mis = new MIS();
                        mis.Company = complainIssue.tbl_complain.tbl_company_branch.tbl_company.Name;
                        mis.State = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.tbl_state.Name;
                        mis.Region = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name;
                        mis.Location= complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.Name;
                        mis.Branch = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.Name;
                        mis.Address = complainIssue.tbl_complain.tbl_company_branch.Address;
                        mis.TypeOfComplain= complainIssue.tbl_complain.tbl_type_of_complain.Name;
                        mis.RequestedDate= complainIssue.tbl_complain.RequstedDate.GetDateString();
                        mis.Complain= complainIssue.tbl_complain.Remark;
                        mis.Issue= complainIssue.Subject;
                        mis.IssueDescription= complainIssue.Description;
                        mis.CloseDate= "closeDate";
                        mis.Aging= complainIssue.tbl_complain.Aging;
                        mis.Status= complainIssue.tbl_issue_status.Name;
                        mis.Remark= complainIssue.Remark;

                        var currentVendorPayment = engineer.tbl_complain_issue.tbl_vendor_payment.FirstOrDefault(s => s.IdVendor == vendor);

                        mis.Vendor = currentVendorPayment.tbl_vendor.Name;
                        mis.IFSC = currentVendorPayment.tbl_vendor.IFSC;
                        mis.Amount = currentVendorPayment.Amount.ToString();
                        mis.PaymentStatus = currentVendorPayment.tbl_payment_status.Name;

                        mis.Engineer = engineer.tbl_service_engineer.FirstName;

                        asd.Add(mis);
                    }

                }

                foreach (var vendor in unpayedVendors)
                {
                    var engineers = complainIssue.tbl_assigned_service_engineer_to_issue.Where(s => s.tbl_service_engineer.IdVendor == vendor);

                    foreach (var engineer in engineers)
                    {
                        var mis = new MIS();
                        mis.Company = complainIssue.tbl_complain.tbl_company_branch.tbl_company.Name;
                        mis.State = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.tbl_state.Name;
                        mis.Region = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name;
                        mis.Location = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.Name;
                        mis.Branch = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.Name;
                        mis.Address = complainIssue.tbl_complain.tbl_company_branch.Address;
                        mis.TypeOfComplain = complainIssue.tbl_complain.tbl_type_of_complain.Name;
                        mis.RequestedDate = complainIssue.tbl_complain.RequstedDate.GetDateString();
                        mis.Complain = complainIssue.tbl_complain.Remark;
                        mis.Issue = complainIssue.Subject;
                        mis.IssueDescription = complainIssue.Description;
                        mis.CloseDate = "closeDate";
                        mis.Aging = complainIssue.tbl_complain.Aging;
                        mis.Status = complainIssue.tbl_issue_status.Name;
                        mis.Remark = complainIssue.Remark;

                        //var currentVendorPayment = engineer.tbl_complain_issue.tbl_vendor_payment.FirstOrDefault(s => s.IdVendor == vendor);

                        mis.Vendor = engineer.tbl_service_engineer.tbl_vendor.Name;
                        mis.IFSC = engineer.tbl_service_engineer.tbl_vendor.IFSC;
                        mis.Amount = "-";
                        mis.PaymentStatus = "-";

                        mis.Engineer = engineer.tbl_service_engineer.FirstName;

                        asd.Add(mis);
                    }

                }

                var fmsEngineers = complainIssue.tbl_assigned_service_engineer_to_issue.Where(s => s.tbl_service_engineer.IdVendor == null);

                foreach (var engineer in fmsEngineers)
                {
                    var mis = new MIS();
                    mis.Company = complainIssue.tbl_complain.tbl_company_branch.tbl_company.Name;
                    mis.State = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.tbl_state.Name;
                    mis.Region = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name;
                    mis.Location = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.tbl_location.Name;
                    mis.Branch = complainIssue.tbl_complain.tbl_company_branch.tbl_branch.Name;
                    mis.Address = complainIssue.tbl_complain.tbl_company_branch.Address;
                    mis.TypeOfComplain = complainIssue.tbl_complain.tbl_type_of_complain.Name;
                    mis.RequestedDate = complainIssue.tbl_complain.RequstedDate.GetDateString();
                    mis.Complain = complainIssue.tbl_complain.Remark;
                    mis.Issue = complainIssue.Subject;
                    mis.IssueDescription = complainIssue.Description;
                    mis.CloseDate = "closeDate";
                    mis.Aging = complainIssue.tbl_complain.Aging;
                    mis.Status = complainIssue.tbl_issue_status.Name;
                    mis.Remark = complainIssue.Remark;

                    //var currentVendorPayment = engineer.tbl_complain_issue.tbl_vendor_payment.FirstOrDefault(s => s.IdVendor == vendor);

                    mis.Vendor = "FMS";
                    mis.IFSC = "-";
                    mis.Amount = "-";
                    mis.PaymentStatus = "-";

                    mis.Engineer = engineer.tbl_service_engineer.FirstName;

                    asd.Add(mis);
                }
            }

            //return null;
            return Json(asd, JsonRequestBehavior.AllowGet);
        }

    }
}