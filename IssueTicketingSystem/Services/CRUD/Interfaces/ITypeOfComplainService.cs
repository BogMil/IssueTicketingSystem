using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface ITypeOfComplainService : IGenericService<TypeOfComplainQueryDto,TypeOfComplainCommandDto>
	{
	    string TypeOfComplainSelectOptions();
	}
}