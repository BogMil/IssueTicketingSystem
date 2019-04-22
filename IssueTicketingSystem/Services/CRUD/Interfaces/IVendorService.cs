using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IVendorService : IGenericService<VendorQueryDto,VendorCommandDto>
	{
	    string VendorSelectOptions();
	    string VendorToPaySelectOption(int idComplainIssue);
	    string VendorThatCanFixComplainIssueSelectOptions(int idComplainIssue);
	}
}