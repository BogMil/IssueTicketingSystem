using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
	public class PartController : 
			GenericController<IPartService,PartViewModel,PartQueryDto,PartCommandDto>
		{
		public PartController(IPartService service) : base(service)
        {
			
        }

		public ActionResult Index()
		{
			return View();
		}

		    public string UnitSelectOptions() => Service.UnitSelectOptions();
		    public string PartTypeSelectOptions() => Service.PartTypeSelectOptions();

		}
}
