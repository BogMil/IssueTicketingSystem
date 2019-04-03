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

	    public List<SelectListItem> RegionSelectOptionsForCustomersCompany(int idState, int idCompany)
	    {
	        return Db.tbl_company_branch
	            .Where(x => x.IdCompany == idCompany)
	            .Where(x => x.tbl_branch.tbl_location.tbl_region.IdState == idState)
	            .Where(x =>x.Active)
                .Select(x =>
	                new SelectListItem
	                {
	                    Text = x.tbl_branch.tbl_location.tbl_region.Name,
	                    Value = x.tbl_branch.tbl_location.tbl_region.Id.ToString()
	                })
	            .Distinct()
	            .OrderBy(x => x.Text)
	            .ToList();
        }
	}
}