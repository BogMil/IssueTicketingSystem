using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IComplainIssueService : IGenericService<ComplainIssueQueryDto,ComplainIssueCommandDto>
	{

	}
}