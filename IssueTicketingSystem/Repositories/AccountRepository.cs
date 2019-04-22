using System;
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

	    public tbl_account CreateAndReturn(tbl_account entity)
	    {
	        entity = ModifyEntityBeforeCreate(entity);
	        Db.tbl_account.Add(entity);
	        Db.SaveChanges();
            return entity;
	    }

	    protected override tbl_account ModifyEntityBeforeCreate(tbl_account entity)
	    {
	        entity.Password= System.Web.Security.Membership.GeneratePassword(10, 3);
	        return entity;
	    }

	    protected override tbl_account ModifyUpdateSourceEntityBeforeUpdate(tbl_account updateSourceEntity, tbl_account oldEntity)
	    {
	        updateSourceEntity.Password = oldEntity.Password;
	        return updateSourceEntity;
	    }

	    protected override void ShouldDeleteEntity(tbl_account entity)
	    {
	        if(entity.tbl_complain.Count != 0)
                throw new Exception("There are complains associated with this account.");
	    }
	}
}