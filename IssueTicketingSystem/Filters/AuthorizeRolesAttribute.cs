using System.Web;
using System.Web.Mvc;
using GenericCSR.Controller;

namespace IssueTicketingSystem.Filters
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }

    public class AuthorizeRolesApiAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesApiAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 200;
            var errorMessage = ErrorMessageCreator.GetUnauthorizedMessage();
            var x = new JsonResult();
            x.Data = errorMessage;
            filterContext.Result = x;

        }
    }

    public class DenyRolesApiAttribute : AuthorizeAttribute
    {
        public DenyRolesApiAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return !base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 200;
            var errorMessage = ErrorMessageCreator.GetUnauthorizedMessage();
            var x = new JsonResult();
            x.Data = errorMessage;
            filterContext.Result = x;

        }
    }

    internal class Http403Result : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = 200;
            //var errorMessage = ErrorMessageCreator.GetMessage();
            //context.HttpContext.Response.Write = JSON(errorMessage;
            //Json(jqGridViewModal, JsonRequestBehavior.AllowGet)
            ////context.HttpContext.Response.Write("Nema iz write");
        }
    }
}