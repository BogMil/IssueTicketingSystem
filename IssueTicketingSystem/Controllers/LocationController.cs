using System.Runtime.InteropServices;
using GenericCSR.Controller;
using System.Web.Mvc;
using GenericCSR;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class LocationController :
            GenericController<ILocationService, LocationViewModel, LocationQueryDto, LocationCommandDto>
    {
        private readonly IRegionService  _regionService;
        private readonly IStateService  _stateService;
        public LocationController(ILocationService service, IStateService stateService, IRegionService regionService) : base(service)
        {
            _stateService = stateService;
            _regionService = regionService;
        }

        public ActionResult Index(int idRegion)
        {
            var region = _regionService.Find(idRegion);
            var state = _stateService.Find(region.IdState);
            var model = new LocationVM { State = state, Region = region };

            return View(model);
        }

        public ActionResult LocationsOfRegion(int idRegion, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = Service.LocationsOfRegion(idRegion, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }

    public class LocationVM
    {
        public StateQueryDto State { get; set; }
        public RegionQueryDto Region { get; set; }
    }
}
