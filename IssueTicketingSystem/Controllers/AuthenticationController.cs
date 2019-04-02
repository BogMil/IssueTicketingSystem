using System;
using System.Web.Mvc;
using IssueTicketingSystem.Services;

namespace IssueTicketingSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AuthenticationService _authenticationService;
        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Authenticate(string email, string password)
        {
            try
            {
                _authenticationService.Authenticate(email, password);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.errorMessage = "Wrong Credentials";
                return View("Index");
            }
        }

        public ActionResult SignOut()
        {
            _authenticationService.SignOut();
            return RedirectToAction("Index", "Authentication");
        }

        public ActionResult Private()
        {
            return View();
        }
    }
}