using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
	public class UnitController : 
			GenericController<IUnitService,UnitViewModel,UnitQueryDto,UnitCommandDto>
		{
		public UnitController(IUnitService service) : base(service)
        {
			
        }

		public ActionResult Index()
		{
			return View();
		}
	}
}
