using System.Web.Mvc;
using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IReplacementService : IGenericService<ReplacementQueryDto,ReplacementCommandDto>
	{
	    StaticPagedList<ReplacementQueryDto> ReplacementsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters);
	    ReplacementEditSelectValues GetReplacementEditSelectValues(int idReplacement);
	}
}