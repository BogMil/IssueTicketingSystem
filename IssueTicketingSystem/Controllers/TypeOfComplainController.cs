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
    public class TypeOfComplainController : 
			GenericController<ITypeOfComplainService,TypeOfComplainViewModel,TypeOfComplainQueryDto,TypeOfComplainCommandDto>
		{
		public TypeOfComplainController(ITypeOfComplainService service) : base(service)
        {
			
        }

		public ActionResult Index()
		{
			return View();
		}
	}
}
