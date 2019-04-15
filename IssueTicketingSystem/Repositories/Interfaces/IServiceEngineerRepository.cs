using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IServiceEngineerRepository : IGenericRepository<tbl_service_engineer>
	{
	    List<SelectListItem> ServiceEngineerOfVendorSelectOptions(int? idVendor);
	}
}