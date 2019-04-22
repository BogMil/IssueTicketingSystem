using System;
using System.Web;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using Microsoft.Ajax.Utilities;

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

	        if (HttpContext.Current.User.IsInRole(CustomRoles.Customer))
	        {
	            if (oldEntity.IdIssueStatus != IssueStatuses.Open.Id)
	                throw new Exception("You can not edit this issue because it is in progress!");
	        }

            if (updateSourceEntity.IdIssueStatus == 0)
	            updateSourceEntity.IdIssueStatus = oldEntity.IdIssueStatus;

	        return updateSourceEntity;
	    }

        

	    protected override void ShouldDeleteEntity(tbl_complain_issue entity)
	    {
	        if (HttpContext.Current.User.IsInRole(CustomRoles.Customer))
	        {
                if(entity.IdIssueStatus!=IssueStatuses.Open.Id)
                    throw new Exception("You can not delete this issue because it is in progress!");
	        }
	    }
	}
}