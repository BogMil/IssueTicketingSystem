using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class PaymentStatusRepository : 
			IssueTicketingSystemRepository<tbl_payment_status,PaymentStatusOrderByPredicateCreator,PaymentStatusWherePredicateCreator>,
		IPaymentStatusRepository
	{
	    public PaymentStatusRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_payment_status entity)
		{
			return entity.Id;		
		}

	    public List<SelectListItem> PaymentStatusSelectOptions()
	    {
	        return Db.tbl_payment_status.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Name})
	            .ToList();
	    }
	}
}