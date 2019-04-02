using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class IssueStatusController :
            GenericController<IIssueStatusService, IssueStatusViewModel, IssueStatusQueryDto, IssueStatusCommandDto>
    {
        //todo delete
        public IssueStatusController(IIssueStatusService service) : base(service)
        {

        }
    }
}
