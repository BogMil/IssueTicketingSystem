using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IPartStatusRepository : IGenericRepository<tbl_part_status>
	{
	    List<SelectListItem> PartStatusSelectOption();
	}
}