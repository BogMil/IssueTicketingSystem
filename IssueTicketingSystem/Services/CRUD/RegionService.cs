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
	public class RegionService : GenericService<RegionQueryDto,RegionCommandDto,IRegionRepository,tbl_region>,IRegionService
	{
		public RegionService(IRegionRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public StaticPagedList<RegionQueryDto> RegionsOfState(int idState, Pager pager, OrderByProperties orderByProperties, string filters)
	    {
	        Repository.CustomWherePredicate = (x) =>
	            x.IdState == idState;
	        var entities = Repository.Filter(pager, filters, orderByProperties);

	        return Mapper.Map<IPagedList<tbl_region>, StaticPagedList<RegionQueryDto>>((PagedList<tbl_region>)entities);
        }

	    public string RegionSelectOptions(int idState)
	    {
	        var sli = Repository.RegionSelectOptions(idState);
	        return DropDownCreator.Create(sli);
	    }

	    public string NullableRegionSelectOptions(int idState)
	    {
	        var sli = Repository.RegionSelectOptions(idState);
	        return DropDownCreator.CreateNullable(sli, "-");
	    }

	    public string NullableRegionSelectOptionsForCustomersCompany(int idState, int idCompany)
	    {
	        var sli = Repository.RegionSelectOptionsForCustomersCompany(idState,idCompany);
	        return DropDownCreator.CreateNullable(sli, "-");
        }
	}
}