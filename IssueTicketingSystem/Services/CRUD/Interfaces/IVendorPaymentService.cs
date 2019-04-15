using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IVendorPaymentService : IGenericService<VendorPaymentQueryDto,VendorPaymentCommandDto>
	{
	    StaticPagedList<VendorPaymentQueryDto> VendorPaymentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters);
	}
}