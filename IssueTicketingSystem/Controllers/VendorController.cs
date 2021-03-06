using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Filters;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    [AuthorizeRoles(
        CustomRoles.Administrator,
        CustomRoles.User
    )]
    public class VendorController :
            GenericController<IVendorService, VendorViewModel, VendorQueryDto, VendorCommandDto>
    {
        public VendorController(IVendorService service) : base(service)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
