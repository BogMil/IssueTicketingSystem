using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IBranchService : IGenericService<BranchQueryDto,BranchCommandDto>
	{
	    StaticPagedList<BranchQueryDto> BranchesOfLocation(int idLocation, Pager pager, OrderByProperties orderByProperties, string filters);
	    string BranchSelectOptions(int idLocation);
	    string NullableBranchSelectOptions(int idLocation);

	    CompanyBranchEditSelectValue GetEditSelectValues(int idBranch);
    }
}