using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class AccountRepository : 
			IssueTicketingSystemRepository<tbl_account,AccountOrderByPredicateCreator,AccountWherePredicateCreator>,
		IAccountRepository
	{
	    public AccountRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_account entity)
		{
			return entity.Id;		
		}

	    public tbl_account GetAccountForCredentials(string email, string password)
	    {
	        return Db.tbl_account
	            .Where(x => x.Email == email)
	            .FirstOrDefault(x => x.Password == password);
	    }
	}
}