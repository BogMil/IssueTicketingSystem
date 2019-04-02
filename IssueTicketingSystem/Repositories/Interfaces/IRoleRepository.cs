using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IRoleRepository : IGenericRepository<tbl_roles>
	{
	    List<SelectListItem> RoleSelectOptions();
	}
}