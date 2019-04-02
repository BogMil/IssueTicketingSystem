using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class PaymentStatusController :
            GenericController<IPaymentStatusService, PaymentStatusViewModel, PaymentStatusQueryDto, PaymentStatusCommandDto>
    {
        //todo delete
        public PaymentStatusController(IPaymentStatusService service) : base(service)
        {

        }
    }
}
