using System;
using System.Web;
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

	    protected override tbl_complain ModifyEntityBeforeCreate(tbl_complain entity)
	    {
	        entity.RequstedDate = DateTime.Now;
	        entity.IdAccount = HttpContext.Current.User.GetIdAccount();
	        entity.Status = IssueStatuses.Open.Text;
	        return entity;
	    }

	    protected override tbl_complain ModifyUpdateSourceEntityBeforeUpdate(tbl_complain updateSourceEntity, tbl_complain oldEntity)
	    {
	        updateSourceEntity.Status = oldEntity.Status;
	        return updateSourceEntity;
	    }
	}
}