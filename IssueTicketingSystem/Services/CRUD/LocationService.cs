using System.Collections.Generic;
using System.Web;
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
	public class LocationService : GenericService<LocationQueryDto,LocationCommandDto,ILocationRepository,tbl_location>,ILocationService
	{
		public LocationService(ILocationRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public StaticPagedList<LocationQueryDto> LocationsOfRegion(int idRegion, Pager pager, OrderByProperties orderByProperties, string filters)
	    {
	        Repository.CustomWherePredicate = (x) =>
	            x.IdRegion== idRegion;
	        var entities = Repository.Filter(pager, filters, orderByProperties);

	        return Mapper.Map<IPagedList<tbl_location>, StaticPagedList<LocationQueryDto>>((PagedList<tbl_location>)entities);
        }

	    public string LocationSelectOptions(int idRegion)
	    {
	        var sli = Repository.LocationSelectOptions(idRegion);
	        return DropDownCreator.Create(sli);
	    }

	    public string NullableLocationSelectOptions(int idRegion)
	    {
	        var sli = Repository.LocationSelectOptions(idRegion);
	        return DropDownCreator.CreateNullable(sli,"-");
	    }

	    public string NullableLocationSelectOptionsForCustomersCompany(int idRegion, int idCompany)
	    {
	        List<SelectListItem> sli;
	        if (HttpContext.Current.User.HasAnyOfRoles(CustomRoles.User, CustomRoles.Administrator))
	            sli = Repository.LocationSelectOptions(idRegion);
	        else
	            sli = Repository.LocationSelectOptionsForCustomersCompany(idRegion, idCompany);

	        return DropDownCreator.CreateNullable(sli, "-");
        }
	}
}