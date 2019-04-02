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
                .OrderBy(x=>x.Name)
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
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