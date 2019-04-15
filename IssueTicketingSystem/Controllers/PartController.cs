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
