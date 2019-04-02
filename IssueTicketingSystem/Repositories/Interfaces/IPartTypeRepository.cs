using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IPartTypeRepository : IGenericRepository<tbl_part_types>
	{
	    List<SelectListItem> PartTypeSelectOptions();
	}
}