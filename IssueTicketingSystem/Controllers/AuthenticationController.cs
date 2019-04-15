using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
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
            var userIdentity = (ClaimsIdentity)User.Identity;
            var claims = userIdentity.Claims;
            var roleClaimType = userIdentity.RoleClaimType;
            var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
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