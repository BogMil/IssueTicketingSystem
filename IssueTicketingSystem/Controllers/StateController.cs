using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
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
