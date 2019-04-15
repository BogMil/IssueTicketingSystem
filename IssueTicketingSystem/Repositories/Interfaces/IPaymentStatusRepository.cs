using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IPaymentStatusRepository : IGenericRepository<tbl_payment_status>
	{
	    List<SelectListItem> PaymentStatusSelectOptions();
	}
}