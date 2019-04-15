using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IComplainService : IGenericService<ComplainQueryDto,ComplainCommandDto>
	{
	    StaticPagedList<ComplainIssueQueryDto> IssuesOfComplain(int idComplain, Pager pager, OrderByProperties orderByProperties, string filters);
	}
}