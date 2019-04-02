using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
	public class EngineerProfessionController : 
			GenericController<IEngineerProfessionService,EngineerProfessionViewModel,EngineerProfessionQueryDto,EngineerProfessionCommandDto>
		{
		public EngineerProfessionController(IEngineerProfessionService service) : base(service)
        {
			
        }

		public ActionResult Index()
		{
			return View();
		}
	}
}
