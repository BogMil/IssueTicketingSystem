using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IAccountRepository : IGenericRepository<tbl_account>
	{
	    tbl_account GetAccountForCredentials(string email, string password);
	    tbl_account CreateAndReturn(tbl_account entity);
	}
}