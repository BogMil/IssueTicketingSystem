using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IRegionRepository : IGenericRepository<tbl_region>
	{
	    List<SelectListItem> RegionSelectOptions(int idState);
	}
}