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
	        return DropDownCreator.Create(selectListItems);
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
	        var selectListItems = Repository.CompanyBranchSelectOptionsForCustomersCompany(idBranch, idCompany);
	        return DropDownCreator.CreateNullable(selectListItems, "-");
        }
	}
}