using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
	public class CompanyBranchController : 
			GenericController<ICompanyBranchService,CompanyBranchViewModel,CompanyBranchQueryDto,CompanyBranchCommandDto>
		{
		public CompanyBranchController(ICompanyBranchService service) : base(service)
        {
			
        }

		public ActionResult Index()
		{
			return View();
		}
	}
}
