using System;
using System.Collections.Generic;
using System.Linq;
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

	    public List<SelectListItem> PartStatusSelectOption()
	    {
	        return Db.tbl_part_status
	            .Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Name})
	            .ToList();
	    }
	}
}