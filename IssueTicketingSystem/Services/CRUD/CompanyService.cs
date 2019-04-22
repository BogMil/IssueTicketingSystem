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
	public class CompanyService : GenericService<CompanyQueryDto,CompanyCommandDto,ICompanyRepository,tbl_company>,ICompanyService
	{
	    private readonly ICompanyBranchRepository _companyBranchRepository;
		public CompanyService(ICompanyRepository repository, IMapper mapper, ICompanyBranchRepository companyBranchRepository) : base(repository, mapper)
		{
		    _companyBranchRepository = companyBranchRepository;
		}

	    public string CompanySelectOptions()
	    {
	        var selectListItems = Repository.CompanySelectOptions();
	        return DropDownCreator.CreateNullable(selectListItems,"FMS");
	    }

	    public StaticPagedList<CompanyBranchQueryDto> BranchOfficesOfCompany(int idCompany, Pager pager, OrderByProperties orderByProperties, string filters)
	    {
	        _companyBranchRepository.CustomWherePredicate = (x) =>
	            x.IdCompany == idCompany;

	        var entities = _companyBranchRepository.Filter(pager, filters, orderByProperties);

	        return Mapper.Map<IPagedList<tbl_company_branch>, StaticPagedList<CompanyBranchQueryDto>>((PagedList<tbl_company_branch>)entities);

        }

	    public string CompanyBranchSelectOptionsForCustomersCompany(int idBranch, int idCompany)
	    {
	        List<SelectListItem> sli;
	        if (HttpContext.Current.User.HasAnyOfRoles(CustomRoles.User, CustomRoles.Administrator))
	            sli = Repository.CompanyBranchSelectOptions(idBranch);
	        else
                sli = Repository.CompanyBranchSelectOptionsForCustomersCompany(idBranch, idCompany);
	        return DropDownCreator.CreateNullable(sli, "-");
        }
	}
}