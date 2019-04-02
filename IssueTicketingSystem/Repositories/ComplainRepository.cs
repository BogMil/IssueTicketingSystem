using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class ComplainRepository : 
			IssueTicketingSystemRepository<tbl_complain,ComplainOrderByPredicateCreator,ComplainWherePredicateCreator>,
		IComplainRepository
	{
	    public ComplainRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_complain entity)
		{
			return entity.Id;		
		}
	}
}