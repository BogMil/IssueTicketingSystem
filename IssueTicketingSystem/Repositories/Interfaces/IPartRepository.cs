using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IPartRepository : IGenericRepository<tbl_part>
	{
	    List<SelectListItem> PartsOfPartTypeSelectOptions(int idPartType);
	}
}