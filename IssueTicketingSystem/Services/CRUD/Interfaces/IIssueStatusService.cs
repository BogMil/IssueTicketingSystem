using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IIssueStatusService : IGenericService<IssueStatusQueryDto,IssueStatusCommandDto>
	{

	}
}