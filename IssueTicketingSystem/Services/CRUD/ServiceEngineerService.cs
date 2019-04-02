using AutoMapper;
using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD
{
	public class ServiceEngineerService : GenericService<ServiceEngineerQueryDto,ServiceEngineerCommandDto,IServiceEngineerRepository,tbl_service_engineer>,IServiceEngineerService
	{
	    private readonly IVendorRepository _vendorRepository;
	    private readonly IEngineerProfessionRepository _engineerProfessionRepository;
	    private readonly ITypeOfComplainRepository _typeOfComplainRepository;

	    public ServiceEngineerService(
	        IServiceEngineerRepository repository, 
	        IMapper mapper,
	        IVendorRepository vendorRepository, 
	        IEngineerProfessionRepository engineerProfessionRepository, 
	        ITypeOfComplainRepository typeOfComplainRepository) : base(repository, mapper)
	    {
	        _vendorRepository = vendorRepository;
	        _engineerProfessionRepository = engineerProfessionRepository;
	        _typeOfComplainRepository = typeOfComplainRepository;
	    }

	    public string VendorSelectOptions()
	    {
	        var selectListItems = _vendorRepository.VendorSelectOptions();
	        return DropDownCreator.CreateNullable(selectListItems, "FMS");

	    }

	    public StaticPagedList<EngineerProfessionQueryDto> ProfessionsOfEngineer(int id, Pager pager, OrderByProperties orderByProperties, string filters)
	    {
	        _engineerProfessionRepository.CustomWherePredicate = (x) =>
	            x.IdServiceEngineer == id;
	        var entities = _engineerProfessionRepository.Filter(pager, filters, orderByProperties);

	        return Mapper.Map<IPagedList<tbl_engineer_profession>, StaticPagedList<EngineerProfessionQueryDto>>((PagedList<tbl_engineer_profession>)entities);
        }

	    public string ProfessionSelectOptions(int idServiceEngineer)
	    {
	        var selectListItems = _typeOfComplainRepository.ProfessionSelectOptions(idServiceEngineer);
	        return DropDownCreator.CreateNullable(selectListItems,"-");

	    }
	}
}