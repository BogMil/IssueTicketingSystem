using GenericCSR.Controller;
using System.Web.Mvc;
using GenericCSR;
using GenericCSR.Sorter;
using IssueTicketingSystem.Filters;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    [AuthorizeRoles(
        CustomRoles.Administrator
    )]
    public class BranchController :
            GenericController<IBranchService, BranchViewModel, BranchQueryDto, BranchCommandDto>
    {

        private readonly IRegionService _regionService;
        private readonly IStateService _stateService;
        private readonly ILocationService _locationService;
        public BranchController(IBranchService service, IStateService stateService, IRegionService regionService, ILocationService locationService) : base(service)
        {
            _stateService = stateService;
            _regionService = regionService;
            _locationService = locationService;
        }

        public ActionResult Index(int idLocation)
        {
            var location = _locationService.Find(idLocation);
            var region = _regionService.Find(location.IdRegion);
            var state = _stateService.Find(region.IdState);
            var model = new BranchVM { State = state, Region = region, Location=location };

            return View(model);
        }

        public ActionResult BranchesOfLocation(int idLocation, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = Service.BranchesOfLocation(idLocation, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }

    public class BranchVM
    {
        public StateQueryDto State { get; set; }
        public RegionQueryDto Region{ get; set; }
        public LocationQueryDto Location{ get; set; }
    }
}
