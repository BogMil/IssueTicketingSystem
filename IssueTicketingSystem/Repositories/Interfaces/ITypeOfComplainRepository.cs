using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface ITypeOfComplainRepository : IGenericRepository<tbl_type_of_complain>
	{
	    List<SelectListItem> ProfessionSelectOptions(int idServiceEngineer);
	    List<SelectListItem> TypeOfComplainSelectOptions();
	}
}