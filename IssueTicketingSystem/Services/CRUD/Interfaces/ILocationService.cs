using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface ILocationService : IGenericService<LocationQueryDto,LocationCommandDto>
	{
	    StaticPagedList<LocationQueryDto> LocationsOfRegion(int idRegion, Pager pager, OrderByProperties orderByProperties, string filters);
	    string LocationSelectOptions(int idRegion);
	    string NullableLocationSelectOptions(int idRegion);

	    string NullableLocationSelectOptionsForCustomersCompany(int idRegion, int idCompany);
	}
}