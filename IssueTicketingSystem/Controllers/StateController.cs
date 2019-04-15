using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Filters;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    [AuthorizeRoles(
        CustomRoles.Administrator
    )]
    public class StateController : 
			GenericController<IStateService,StateViewModel,StateQueryDto,StateCommandDto>
		{
		public StateController(IStateService service) : base(service)
        {
			
        }

		public ActionResult Index()
		{
			return View();
		}
	}
}
