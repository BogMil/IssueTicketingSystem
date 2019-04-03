using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IRegionService : IGenericService<RegionQueryDto,RegionCommandDto>
	{
	    StaticPagedList<RegionQueryDto> RegionsOfState(int idState, Pager pager, OrderByProperties orderByProperties, string filters);
	    string RegionSelectOptions(int idState);
	    string NullableRegionSelectOptions(int idState);

	    string NullableRegionSelectOptionsForCustomersCompany(int idState, int idCompany);
	}
}