using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class VendorPaymentRepository : 
			IssueTicketingSystemRepository<tbl_vendor_payment,VendorPaymentOrderByPredicateCreator,VendorPaymentWherePredicateCreator>,
		IVendorPaymentRepository
	{
	    public VendorPaymentRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_vendor_payment entity)
		{
			return entity.Id;		
		}

	    protected override tbl_vendor_payment ModifyUpdateSourceEntityBeforeUpdate(tbl_vendor_payment updateSourceEntity,
	        tbl_vendor_payment oldEntity)
	    {
	        updateSourceEntity.IdVendor = oldEntity.IdVendor;

	        return updateSourceEntity;
	    }
	}
}