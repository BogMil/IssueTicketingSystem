using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IRepairmentService : IGenericService<RepairmentQueryDto,RepairmentCommandDto>
	{
	    StaticPagedList<RepairmentQueryDto> RepairmentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties, string filters);
	    RepairmentEditSelectValues GetRepairmentEditSelectValues(int idRepairment);
	}
}