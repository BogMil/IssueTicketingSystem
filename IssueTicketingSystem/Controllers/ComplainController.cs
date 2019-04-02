using GenericCSR.Controller;
using System.Web.Mvc;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class ComplainController :
            GenericController<IComplainService, ComplainViewModel, ComplainQueryDto, ComplainCommandDto>
    {

        private readonly ITypeOfComplainService _typeOfComplainService;
        public ComplainController(IComplainService service, ITypeOfComplainService typeOfComplainService) : base(service)
        {
            _typeOfComplainService = typeOfComplainService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string TypeOfComplainSelectOptions() => _typeOfComplainService.TypeOfComplainSelectOptions();

    }
}
