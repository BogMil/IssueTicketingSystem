using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IUnitRepository : IGenericRepository<tbl_unit>
	{
	    List<SelectListItem> UnitSelectOptions();
	}
}