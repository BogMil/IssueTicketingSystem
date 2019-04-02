using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
	public class RoleController : 
			GenericController<IRoleService,RoleViewModel,RoleQueryDto,RoleCommandDto>
		{
		public RoleController(IRoleService service) : base(service)
        {
			
        }

		public ActionResult Index()
		{
			return View();
		}
	}
}
