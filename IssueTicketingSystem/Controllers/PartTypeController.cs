using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
	public class PartTypeController : 
			GenericController<IPartTypeService,PartTypeViewModel,PartTypeQueryDto,PartTypeCommandDto>
		{
		public PartTypeController(IPartTypeService service) : base(service){}

		public ActionResult Index()
		{
			return View();
		}
	}
}
