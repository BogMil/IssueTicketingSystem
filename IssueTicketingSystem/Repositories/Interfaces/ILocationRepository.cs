using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface ILocationRepository : IGenericRepository<tbl_location>
	{
	    List<SelectListItem> LocationSelectOptions(int idRegion);
	}
}