using System;
using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
    public class VendorRepository :
            IssueTicketingSystemRepository<tbl_vendor, VendorOrderByPredicateCreator, VendorWherePredicateCreator>,
        IVendorRepository
    {
        public VendorRepository(IssueTicketingSystemEntities context) : base(context)
        {
        }

        protected override object GetPrimaryKey(tbl_vendor entity)
        {
            return entity.Id;
        }

        public List<SelectListItem> VendorSelectOptions()
        {
            return Db.tbl_vendor
                .Where(x => x.Active)
                .Where(x => x.tbl_service_engineer.Count>0)
                .OrderBy(x=>x.Name)
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
        }

        public List<SelectListItem> VendorToPaySelectOption(int idComplainIssue)
        {
            List<int> payedVendors = Db.tbl_vendor_payment
                .Where(x => x.IdIssue == idComplainIssue)
                .Where(x => x.IdVendor != null)
                .Select(x => (int) x.IdVendor)
                .ToList();

            return Db.tbl_complain_issue
                .Where(x => x.Id == idComplainIssue)
                .SelectMany(x =>
                    x.tbl_assigned_service_engineer_to_issue.Select(s => s.tbl_service_engineer.tbl_vendor))
                .Distinct()
                .Where(x=>x!=null)
                .Where(x=>!payedVendors.Contains(x.Id))
                .Select(x=>new SelectListItem{Text = x.Name, Value = x.Id.ToString()})
                .ToList();
        }

        protected override void ShouldDeleteEntity(tbl_vendor entity)
        {
            if(entity.tbl_additional_payment.Count>0 ||
               entity.tbl_service_engineer.Count>0 ||
               entity.tbl_vendor_payment.Count>0)
                throw  new Exception("Unable to delete. Selected Vendor may have service engineers and/or is included in payments");
        }
    }
}