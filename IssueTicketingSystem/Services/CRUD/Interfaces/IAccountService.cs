using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IAccountService : IGenericService<AccountQueryDto,AccountCommandDto>
	{
	    AccountQueryDto GetAccountForCredentials(string email, string password);
	}
}