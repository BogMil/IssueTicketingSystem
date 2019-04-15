using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class RepairmentRepository : 
			IssueTicketingSystemRepository<tbl_repairment,RepairmentOrderByPredicateCreator,RepairmentWherePredicateCreator>,
		IRepairmentRepository
	{
	    public RepairmentRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_repairment entity)
		{
			return entity.Id;		
		}
	}
}