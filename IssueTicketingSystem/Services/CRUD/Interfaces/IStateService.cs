using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IStateService : IGenericService<StateQueryDto,StateCommandDto>
	{
	    string StateSelectOptions();
	    string NullableStateSelectOptions();

	}
}