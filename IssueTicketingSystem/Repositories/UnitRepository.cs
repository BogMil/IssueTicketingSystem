using System;
using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class UnitRepository : 
			IssueTicketingSystemRepository<tbl_unit,UnitOrderByPredicateCreator,UnitWherePredicateCreator>,
		IUnitRepository
	{
	    public UnitRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_unit entity)
		{
			return entity.Id;		
		}

	    public List<SelectListItem> UnitSelectOptions()
	    {
	        return Db.tbl_unit
	            .OrderBy(x=>x.Name)
	            .Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name}).ToList();
	    }

	    protected override void ShouldDeleteEntity(tbl_unit entity)
	    {
	        if(entity.tbl_part.Count>0)
	            throw new Exception("There are parts with selected unit. First delete parts with selected unit");
	    }
	}
}