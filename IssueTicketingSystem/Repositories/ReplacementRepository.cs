using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class ReplacementRepository : 
			IssueTicketingSystemRepository<tbl_replacement,ReplacementOrderByPredicateCreator,ReplacementWherePredicateCreator>,
		IReplacementRepository
	{
	    public ReplacementRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_replacement entity)
		{
			return entity.Id;		
		}
	}
}