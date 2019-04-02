using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class PaymentStatusService : GenericService<PaymentStatusQueryDto,PaymentStatusCommandDto,IPaymentStatusRepository,tbl_payment_status>,IPaymentStatusService
	{
		public PaymentStatusService(IPaymentStatusRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
	}
}