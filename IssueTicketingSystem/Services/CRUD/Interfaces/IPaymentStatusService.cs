using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IPaymentStatusService : IGenericService<PaymentStatusQueryDto,PaymentStatusCommandDto>
	{
	    string PaymentStatusSelectOptions();
	}
}