using System.Collections.Generic;
using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IVendorRepository : IGenericRepository<tbl_vendor>
	{
	    List<SelectListItem> VendorThatHaveEngineersSelectOptions();
	    List<SelectListItem> VendorToPaySelectOption(int idComplainIssue);
	    List<SelectListItem> VendorSelectOptions();
	    List<SelectListItem> VendorThatCanFixComplainTypeSelectOptions(int idTypeOfComplain);
	}
}