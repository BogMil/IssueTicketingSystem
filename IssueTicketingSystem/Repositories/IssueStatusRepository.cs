using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class IssueStatusRepository : 
			IssueTicketingSystemRepository<tbl_issue_status,IssueStatusOrderByPredicateCreator,IssueStatusWherePredicateCreator>,
		IIssueStatusRepository
	{
	    public IssueStatusRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_issue_status entity)
		{
			return entity.Id;		
		}
	}
}