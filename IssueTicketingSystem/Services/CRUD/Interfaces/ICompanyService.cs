using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface ICompanyService : IGenericService<CompanyQueryDto,CompanyCommandDto>
	{
	    string CompanySelectOptions();
	    StaticPagedList<CompanyBranchQueryDto> BranchOfficesOfCompany(int idCompany, Pager pager, OrderByProperties orderByProperties, string filters);
	}
}