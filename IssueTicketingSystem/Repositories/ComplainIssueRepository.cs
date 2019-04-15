using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class ComplainIssueRepository : 
			IssueTicketingSystemRepository<tbl_complain_issue,ComplainIssueOrderByPredicateCreator,ComplainIssueWherePredicateCreator>,
		IComplainIssueRepository
	{
	    public ComplainIssueRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_complain_issue entity)
		{
			return entity.Id;		
		}

	    protected override tbl_complain_issue ModifyEntityBeforeCreate(tbl_complain_issue entity)
	    {
	        entity.IdIssueStatus = IssueStatuses.Open.Id;
	        return entity;
	    }

	    protected override tbl_complain_issue ModifyUpdateSourceEntityBeforeUpdate(tbl_complain_issue updateSourceEntity,
	        tbl_complain_issue oldEntity)
	    {
	        if (updateSourceEntity.IdIssueStatus == 0)
	            updateSourceEntity.IdIssueStatus = oldEntity.IdIssueStatus;

	        return updateSourceEntity;
	    }
	}
}