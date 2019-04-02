using System;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using Microsoft.Ajax.Utilities;

namespace IssueTicketingSystem.Repositories
{
	public class PartStatusRepository : 
			IssueTicketingSystemRepository<tbl_part_status,PartStatusOrderByPredicateCreator,PartStatusWherePredicateCreator>,
		IPartStatusRepository
	{
	    public PartStatusRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_part_status entity)
		{
			return entity.Id;		
		}
	}
}