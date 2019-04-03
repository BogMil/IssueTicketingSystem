using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IStateRepository : IGenericRepository<tbl_state>
	{
	    List<SelectListItem> StateSelectOptions();
	    List<SelectListItem> StateSelectOptionsForCustomersCompany(int idCompany);
	}
}