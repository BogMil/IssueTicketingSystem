using System;
using GenericCSR.Controller;
using System.Web.Mvc;
using GenericCSR;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class CompanyController :
            GenericController<ICompanyService, CompanyViewModel, CompanyQueryDto, CompanyCommandDto>
    {
        private readonly IBranchService _branchService;
        private readonly ILocationService _locationService;
        private readonly IStateService _stateService;
        private readonly IRegionService _regionService;
        private readonly ICompanyBranchService _companyBranchService;
        public CompanyController(
            ICompanyService service,
            IBranchService branchService,
            ILocationService locationService,
            IStateService stateService,
            IRegionService regionService, ICompanyBranchService companyBranchService) : base(service)
        {
            _branchService = branchService;
            _locationService = locationService;
            _stateService = stateService;
            _regionService = regionService;
            _companyBranchService = companyBranchService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BranchOfficesOfCompany(int idCompany, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = Service.BranchOfficesOfCompany(idCompany, pager, orderByProperties, filters);
            var vm = JqGridViewModelFactory<CompanyBranchViewModel, CompanyBranchQueryDto>(data);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        public string StateSelectOptions() => _stateService.NullableStateSelectOptions();
        public string RegionSelectOptions(int idState) => _regionService.NullableRegionSelectOptions(idState);
        public string LocationSelectOptions(int idRegion) => _locationService.NullableLocationSelectOptions(idRegion);
        public string BranchSelectOptions(int idLocation) => _branchService.NullableBranchSelectOptions(idLocation);
        public string Empty() => "<select><option>-</option></select>";

        public ActionResult CreateCompanyBranch(CompanyBranchCommandDto dto)
        {
            try
            {
                _companyBranchService.Create(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateCompanyBranch(CompanyBranchCommandDto dto)
        {
            try
            {
                _companyBranchService.Update(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteCompanyBranch(int id)
        {
            try
            {
                _companyBranchService.Delete(id);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetEditSelectValues(int idBranch)
        {
            var selectValues = _branchService.GetEditSelectValues(idBranch);
            return Json(selectValues, JsonRequestBehavior.AllowGet);
        }
    }

    
}
