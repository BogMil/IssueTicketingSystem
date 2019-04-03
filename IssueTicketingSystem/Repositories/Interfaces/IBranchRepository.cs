using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IBranchRepository : IGenericRepository<tbl_branch>
	{
	    List<SelectListItem> BranchSelectOptions(int idLocation);
	    List<SelectListItem> BranchSelectOptionsForCustomersCompany(int idLocation, int idCompany);
	}
}