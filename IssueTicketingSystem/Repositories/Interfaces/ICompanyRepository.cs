using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface ICompanyRepository : IGenericRepository<tbl_company>
	{
	    List<SelectListItem> CompanySelectOptions();
	    List<SelectListItem> CompanyBranchSelectOptionsForCustomersCompany(int idBranch, int idCompany);
	    List<SelectListItem> CompanyBranchSelectOptions(int idBranch);

	}
}