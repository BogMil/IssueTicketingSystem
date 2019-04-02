using System;
using System.Collections.Generic;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class PartRepository : 
			IssueTicketingSystemRepository<tbl_part,PartOrderByPredicateCreator,PartWherePredicateCreator>,
		IPartRepository
	{
	    public PartRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_part entity)
		{
			return entity.Id;		
		}

	    protected override void ShouldDeleteEntity(tbl_part entity)
	    {
	        if(entity.tbl_replacement.Count > 0)
                throw new Exception("Selected part is used as replacemend. To delete it, first delete all replacement associated with it.");
	    }
	}
}