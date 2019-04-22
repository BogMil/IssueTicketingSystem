using System;
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
        CustomRoles.Administrator,
        CustomRoles.User,
        CustomRoles.Customer
    )]
    public class ComplainController :
            GenericController<IComplainService, ComplainViewModel, ComplainQueryDto, ComplainCommandDto>
    {

        private readonly ITypeOfComplainService _typeOfComplainService;
        private readonly IBranchService _branchService;
        private readonly ILocationService _locationService;
        private readonly IStateService _stateService;
        private readonly IRegionService _regionService;
        private readonly ICompanyService _companyService;
        private readonly IComplainIssueService _complainIssueService;
        private readonly IVendorService _vendorService;
        private readonly IServiceEngineerService _serviceEngineerService;
        private readonly IAssignmentService _assignmentService;
        private readonly IReplacementService _replacementService;
        private readonly IPartTypeService _partTypeService;
        private readonly IPartService _partService;
        private readonly IPartStatusService _partStatusService;
        private readonly IRepairmentService _repairmentService;
        private readonly IVendorPaymentService _vendorPaymentService;
        private readonly IPaymentStatusService _paymentStatusService;
        private readonly IIssueStatusService _issueStatusService;


        public ComplainController(IComplainService service, ITypeOfComplainService typeOfComplainService,
            ILocationService locationService, IBranchService branchService, IStateService stateService,
            IRegionService regionService, ICompanyService companyService, IComplainIssueService complainIssueService,
            IVendorService vendorService, IServiceEngineerService serviceEngineerService,
            IAssignmentService assignmentService, IReplacementService replacementService,
            IPartTypeService partTypeService, IPartService partService,
            IPartStatusService partStatusService, IRepairmentService repairmentService, 
            IVendorPaymentService vendorPaymentService, IPaymentStatusService paymentStatusService, IIssueStatusService issueStatusService) : base(service)
        {
            _typeOfComplainService = typeOfComplainService;
            _locationService = locationService;
            _branchService = branchService;
            _stateService = stateService;
            _regionService = regionService;
            _companyService = companyService;
            _complainIssueService = complainIssueService;
            _vendorService = vendorService;
            _serviceEngineerService = serviceEngineerService;
            _assignmentService = assignmentService;
            _replacementService = replacementService;
            _partTypeService = partTypeService;
            _partService = partService;
            _partStatusService = partStatusService;
            _repairmentService = repairmentService;
            _vendorPaymentService = vendorPaymentService;
            _paymentStatusService = paymentStatusService;
            _issueStatusService = issueStatusService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IssuesOfComplain(int idComplain, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = Service.IssuesOfComplain(idComplain, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ComplainsOfCompany(Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = Service.ComplainsOfCompany(pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public string TypeOfComplainSelectOptions() => _typeOfComplainService.TypeOfComplainSelectOptions();
        public string StateSelectOptions() => _stateService.NullableStateSelectOptionsForCustomersCompany(User.GetIdCompany());
        public string RegionSelectOptions(int idState) => _regionService.NullableRegionSelectOptionsForCustomersCompany(idState, User.GetIdCompany());
        public string LocationSelectOptions(int idRegion) => _locationService.NullableLocationSelectOptionsForCustomersCompany(idRegion, User.GetIdCompany());
        public string BranchSelectOptions(int idLocation) => _branchService.NullableBranchSelectOptionsForCustomersCompany(idLocation, User.GetIdCompany());
        public string CompanyBranchSelectOptions(int idBranch) => _companyService.CompanyBranchSelectOptionsForCustomersCompany(idBranch, User.GetIdCompany());
        public string VendorSelectOptions() => _vendorService.VendorSelectOptions();//delete;
        public string ServiceEngineerOfVendorSelectOptions(int? idVendor = null) => _serviceEngineerService.ServiceEngineerOfVendorSelectOptions(idVendor);
        public string PartTypeThatHavePartsSelectOption() => _partTypeService.PartTypeThatHavePartsSelectOption();
        public string PartsOfPartTypeSelectOption(int idPartType) => _partService.PartsOfPartTypeSelectOption(idPartType);
        public string PartStatusSelectOption() => _partStatusService.PartStatusSelectOption();
        public string PaymentStatusSelectOptions() => _paymentStatusService.PaymentStatusSelectOptions();
        public string VendorToPaySelectOption(int idComplainIssue) => _vendorService.VendorToPaySelectOption(idComplainIssue);
        public string IssueStatusSelectOptions() => _issueStatusService.IssueStatusSelectOptions();
        public string VendorThatCanFixComplainIssueSelectOptions(int idComplainIssue) => _vendorService.VendorThatCanFixComplainIssueSelectOptions(idComplainIssue);
        public string GetRefreshedStatusForComplain(int idComplain) => Service.GetRefreshedStatusForComplain(idComplain);
        public string Empty() => "<select><option>-</option></select>";

        public ActionResult GetEditSelectValues(int idComplain)
        {
            var esv = Service.GetEditSelectValues(idComplain);
            return Json(esv, JsonRequestBehavior.AllowGet);
        }

        #region COMPLAIN ISSUE
        public ActionResult CreateComplainIssue(ComplainIssueCommandDto dto)
        {
            try
            {
                _complainIssueService.Create(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateComplainIssue(ComplainIssueCommandDto dto)
        {
            try
            {
                _complainIssueService.Update(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteComplainIssue(int id)
        {
            try
            {
                _complainIssueService.Delete(id);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ComplainIssueDetails(int idComplainIssue)
        {
            var complainIssue = _complainIssueService.Find(idComplainIssue);
            ViewBag.IdComplainIssue = idComplainIssue;
            ViewBag.ComplainIssue = complainIssue;
            return View();
        }

        #endregion

        #region ASSIGNMENT
        public ActionResult AssignmentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = _assignmentService.AssignmentsOfComplainIssue(idComplainIssue, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssignmentEditSelectValues(int idAssignment)
        {
            var esv = _assignmentService.GetAssignmentEditSelectValues(idAssignment);
            return Json(esv, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateAssignment(AssignmentCommandDto dto)
        {
            try
            {
                _assignmentService.Create(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateAssignment(AssignmentCommandDto dto)
        {
            try
            {
                _assignmentService.Update(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteAssignment(int id)
        {
            try
            {
                _assignmentService.Delete(id);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region REPLACEMENT
        public ActionResult ReplacementsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = _replacementService.ReplacementsOfComplainIssue(idComplainIssue, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetReplacementEditSelectValues(int idReplacement)
        {
            var esv= _replacementService.GetReplacementEditSelectValues(idReplacement);
            return Json(esv, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateReplacement(ReplacementCommandDto dto)
        {
            try
            {
                _replacementService.Create(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateReplacement(ReplacementCommandDto dto)
        {
            try
            {
                _replacementService.Update(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteReplacement(int id)
        {
            try
            {
                _replacementService.Delete(id);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion


        #region REPAIRMENTS
        public ActionResult RepairmentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = _repairmentService.RepairmentsOfComplainIssue(idComplainIssue, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRepairmentEditSelectValues(int idRepairment)
        {
            var esv = _repairmentService.GetRepairmentEditSelectValues(idRepairment);
            return Json(esv, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateRepairment(RepairmentCommandDto dto)
        {
            try
            {
                _repairmentService.Create(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateRepairment(RepairmentCommandDto dto)
        {
            try
            {
                _repairmentService.Update(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteRepairment(int id)
        {
            try
            {
                _repairmentService.Delete(id);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region VENODR PAYMENTS
        public ActionResult VendorPaymentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = _vendorPaymentService.VendorPaymentsOfComplainIssue(idComplainIssue, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateVendorPayment(VendorPaymentCommandDto dto)
        {
            try
            {
                _vendorPaymentService.Create(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateVendorPayment(VendorPaymentCommandDto dto)
        {
            try
            {
                _vendorPaymentService.Update(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteVendorPayment(int id)
        {
            try
            {
                _vendorPaymentService.Delete(id);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}
