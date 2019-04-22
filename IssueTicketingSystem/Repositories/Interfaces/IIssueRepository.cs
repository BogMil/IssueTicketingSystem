using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IIssueStatusRepository : IGenericRepository<tbl_issue_status>
	{
	    List<SelectListItem> IssueStatusSelectOptions();
	}
}