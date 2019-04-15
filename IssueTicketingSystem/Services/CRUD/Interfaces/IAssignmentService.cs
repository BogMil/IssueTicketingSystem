using System.Web.Mvc;
using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IAssignmentService : IGenericService<AssignmentQueryDto,AssignmentCommandDto>
	{
	    StaticPagedList<AssignmentQueryDto> AssignmentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters);
	    AssignmentEditSelectValues GetAssignmentEditSelectValues(int idAssignment);
	}
}