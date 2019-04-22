using System;
using System.Linq;
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
	        updateSourceEntity.IdAccount = oldEntity.IdAccount;
	        updateSourceEntity.RequstedDate = oldEntity.RequstedDate;


	        if (HttpContext.Current.User.IsInRole(CustomRoles.Customer))
	        {
	            var numberOfIssuesWithStatusDiferentFromOpen = oldEntity.tbl_complain_issue.Count(x => x.IdIssueStatus != IssueStatuses.Open.Id);
	            if (numberOfIssuesWithStatusDiferentFromOpen > 0)
	                throw new Exception("You can not edit this compain because it has issues in progress!");
	        }

            return updateSourceEntity;
	    }

	    protected override void ShouldDeleteEntity(tbl_complain entity)
	    {
	        if (HttpContext.Current.User.IsInRole(CustomRoles.Customer))
	        {
	            var numberOfIssuesWithStatusOpen = entity.tbl_complain_issue.Count(x => x.IdIssueStatus == IssueStatuses.Open.Id);
	            if (numberOfIssuesWithStatusOpen > 0)
	                throw new Exception("You can not delete this compain because it has issues in progress!");
	        }
        }

	    public string GetRefreshedStatusForComplain(int idComplain)
        {
	        
	        var complain = Db.tbl_complain.Find(idComplain);
	        var numberOfIssuesWithStatusAwaitingApproval =complain.tbl_complain_issue.Count(x => x.IdIssueStatus == IssueStatuses.AwaitingApproval.Id);
	        var numberOfIssuesWithStatusOpen=complain.tbl_complain_issue.Count(x => x.IdIssueStatus == IssueStatuses.Open.Id);
	        var numberOfIssuesWithStatusClose=complain.tbl_complain_issue.Count(x => x.IdIssueStatus == IssueStatuses.Close.Id);
	        var numberOfIssuesWithStatusUnderProcess=complain.tbl_complain_issue.Count(x => x.IdIssueStatus == IssueStatuses.UnderProcess.Id);
            var numberOfIssues = complain.tbl_complain_issue.Count;

            string status = IssueStatuses.UnderProcess.Text;

	        if (numberOfIssues == numberOfIssuesWithStatusClose)
	        {
	            status = IssueStatuses.Close.Text;
	        }

	        if (numberOfIssues == numberOfIssuesWithStatusAwaitingApproval)
	        {
	            status = IssueStatuses.AwaitingApproval.Text;
	        }

            if (numberOfIssues == numberOfIssuesWithStatusOpen)
	        {
	            status = IssueStatuses.Open.Text;
	        }

            if (numberOfIssues == numberOfIssuesWithStatusUnderProcess)
	        {
	            status = IssueStatuses.UnderProcess.Text;
            }

	        complain.Status = status;

            Db.SaveChanges();

            return status;
        }


    }
}