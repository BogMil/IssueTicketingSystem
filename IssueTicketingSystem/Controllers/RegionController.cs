using GenericCSR.Controller;
using System.Web.Mvc;
using GenericCSR;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class RegionController :
            GenericController<IRegionService, RegionViewModel, RegionQueryDto, RegionCommandDto>
    {
        private readonly IStateService _stateService;
        public RegionController(IRegionService service, IStateService stateService) : base(service)
        {
            _stateService = stateService;
        }

        public ActionResult Index(int idState)
        {
            var state =_stateService.Find(idState);
            return View(state);
        }

        public ActionResult RegionsOfState(int idState, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = Service.RegionsOfState(idState, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
