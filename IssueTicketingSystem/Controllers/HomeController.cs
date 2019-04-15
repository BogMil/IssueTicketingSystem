using System.Web.Mvc;
using IssueTicketingSystem.Filters;

namespace IssueTicketingSystem.Controllers
{
    [AuthorizeRoles(
        CustomRoles.Administrator,
        CustomRoles.User,
        CustomRoles.Customer
    )]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}