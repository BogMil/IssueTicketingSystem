using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class AccountController :
            GenericController<IAccountService, AccountViewModel, AccountQueryDto, AccountCommandDto>
    {
        private readonly IRoleService _roleService;
        private readonly ICompanyService _companyService;
        public AccountController(IAccountService service, IRoleService roleService, ICompanyService companyService) : base(service)
        {
            _roleService = roleService;
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string RoleSelectOptions() => _roleService.RoleSelectOptions();
        public string CompanySelectOptions() => _companyService.CompanySelectOptions();

    }
}
