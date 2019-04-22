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
	public class BranchService : GenericService<BranchQueryDto,BranchCommandDto,IBranchRepository,tbl_branch>,IBranchService
	{
		public BranchService(IBranchRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public StaticPagedList<BranchQueryDto> BranchesOfLocation(int idLocation, Pager pager, OrderByProperties orderByProperties, string filters)
	    {
	        Repository.CustomWherePredicate = (x) =>
	            x.IdLocation== idLocation;
	        var entities = Repository.Filter(pager, filters, orderByProperties);

	        return Mapper.Map<IPagedList<tbl_branch>, StaticPagedList<BranchQueryDto>>((PagedList<tbl_branch>)entities);
        }

	    public string BranchSelectOptions(int idLocation)
	    {
	        var selectListItems = Repository.BranchSelectOptions(idLocation);
	        return DropDownCreator.Create(selectListItems);
	    }

	    public string NullableBranchSelectOptions(int idLocation)
	    {
	        var selectListItems = Repository.BranchSelectOptions(idLocation);
	        return DropDownCreator.CreateNullable(selectListItems, "-");
	    }

	    public CompanyBranchEditSelectValue GetEditSelectValues(int idBranch)
	    {

	        var companyBranch = Repository.Find(idBranch);
	        return Mapper.Map<tbl_branch, CompanyBranchEditSelectValue>(companyBranch);
	    }

	    public string NullableBranchSelectOptionsForCustomersCompany(int idLocation, int idCompany)
	    {
	        List<SelectListItem> sli;
	        if (HttpContext.Current.User.HasAnyOfRoles(CustomRoles.User, CustomRoles.Administrator))
	            sli = Repository.BranchSelectOptions(idLocation);
	        else
	            sli = Repository.BranchSelectOptionsForCustomersCompany(idLocation, idCompany);

	        return DropDownCreator.CreateNullable(sli, "-");
        }
	}
}