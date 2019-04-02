using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class EngineerProfessionRepository : 
			IssueTicketingSystemRepository<tbl_engineer_profession,EngineerProfessionOrderByPredicateCreator,EngineerProfessionWherePredicateCreator>,
		IEngineerProfessionRepository
	{
	    public EngineerProfessionRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_engineer_profession entity)
		{
			return entity.Id;		
		}
	}
}