using System;
using GenericCSR.Controller;
using System.Web.Mvc;
using GenericCSR;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Controllers
{
    public class ServiceEngineerController :
            GenericController<IServiceEngineerService, ServiceEngineerViewModel, ServiceEngineerQueryDto, ServiceEngineerCommandDto>
    {

        private readonly IEngineerProfessionService _engineerProfessionService;
        public ServiceEngineerController(IServiceEngineerService service, IEngineerProfessionService engineerProfessionService) : base(service)
        {
            _engineerProfessionService = engineerProfessionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProfessionsOfEngineer(int id, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var data = Service.ProfessionsOfEngineer(id, pager, orderByProperties, filters);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public string VendorSelectOptions() => Service.VendorSelectOptions();
        public string ProfessionSelectOptions(int? idServiceEngineer)
        {
            return idServiceEngineer == null ? null : Service.ProfessionSelectOptions((int) idServiceEngineer);
        }

        public ActionResult AddProfessionToEngineer(EngineerProfessionCommandDto dto)
        {
            try
            {
                _engineerProfessionService.Create(dto);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RemoveProfessionFromEngineer(int id)
        {
            try
            {
                _engineerProfessionService.Delete(id);
                return Json(SuccessMessageCreator.GetMessage(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(ErrorMessageCreator.GetMessage(e), JsonRequestBehavior.AllowGet);
            }
        }

    }
}
