using System;
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
        private readonly IBranchService _branchService;
        private readonly ILocationService _locationService;
        private readonly IStateService _stateService;
        private readonly IRegionService _regionService;
        private readonly ICompanyService _companyService;

        public ComplainController(IComplainService service, ITypeOfComplainService typeOfComplainService,
            ILocationService locationService, IBranchService branchService, IStateService stateService,
            IRegionService regionService, ICompanyService companyService) : base(service)
        {
            _typeOfComplainService = typeOfComplainService;
            _locationService = locationService;
            _branchService = branchService;
            _stateService = stateService;
            _regionService = regionService;
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public string TypeOfComplainSelectOptions() => _typeOfComplainService.TypeOfComplainSelectOptions();
        public string StateSelectOptions() => _stateService.NullableStateSelectOptionsForCustomersCompany(User.GetIdCompany());
        public string RegionSelectOptions(int idState) => _regionService.NullableRegionSelectOptionsForCustomersCompany(idState, User.GetIdCompany());
        public string LocationSelectOptions(int idRegion) => _locationService.NullableLocationSelectOptionsForCustomersCompany(idRegion, User.GetIdCompany());
        public string BranchSelectOptions(int idLocation) => _branchService.NullableBranchSelectOptionsForCustomersCompany(idLocation, User.GetIdCompany());
        public string CompanyBranchSelectOptions(int idBranch) => _companyService.CompanyBranchSelectOptionsForCustomersCompany(idBranch, User.GetIdCompany());

        public string Empty() => "<select><option>-</option></select>";

    }
}
