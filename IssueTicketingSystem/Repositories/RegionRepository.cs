using System;
using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class RegionRepository : 
			IssueTicketingSystemRepository<tbl_region,RegionOrderByPredicateCreator,RegionWherePredicateCreator>,
		IRegionRepository
	{
	    public RegionRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_region entity)
		{
			return entity.Id;		
		}

	    protected override void ShouldDeleteEntity(tbl_region entity)
	    {
	        if (entity.tbl_location.Count > 0)
	            throw new Exception("Region has locations.First delete locations");
        }

	    public List<SelectListItem> RegionSelectOptions(int idState)
	    {
	        return Db.tbl_region
	            .Where(x => x.IdState == idState)
	            .Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()})
	            .OrderBy(x=>x.Text)
	            .ToList();
	    }
	}
}