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
	    StaticPagedList<ComplainQueryDto> ComplainsOfCompany(Pager pager, OrderByProperties orderByProperties, string filters);
	    ComplainEditSelectValues GetEditSelectValues(int idComplain);
	    string GetRefreshedStatusForComplain(int idComplain);
	}
}