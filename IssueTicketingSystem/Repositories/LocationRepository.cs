using System;
using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class LocationRepository : 
			IssueTicketingSystemRepository<tbl_location,LocationOrderByPredicateCreator,LocationWherePredicateCreator>,
		ILocationRepository
	{
	    public LocationRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_location entity)
		{
			return entity.Id;		
		}

	    protected override void ShouldDeleteEntity(tbl_location entity)
	    {
	        if (entity.tbl_branch.Count > 0)
	            throw new Exception("Location has branches.First delete branches");
        }

	    public List<SelectListItem> LocationSelectOptions(int idRegion)
	    {
	        return Db.tbl_location
	            .Where(x => x.IdRegion == idRegion)
	            .Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()})
	            .OrderBy(x=>x.Text)
	            .ToList();
	    }

	    public List<SelectListItem> LocationSelectOptionsForCustomersCompany(int idRegion, int idCompany)
	    {
	        return Db.tbl_company_branch
	            .Where(x => x.IdCompany == idCompany)
	            .Where(x=>x.tbl_branch.tbl_location.IdRegion==idRegion)
	            .Where(x =>x.Active)
	            .Select(x =>
	                new SelectListItem
	                {
	                    Text = x.tbl_branch.tbl_location.Name,
	                    Value = x.tbl_branch.tbl_location.Id.ToString()
	                })
	            .Distinct()
	            .OrderBy(x => x.Text)
	            .ToList();
        }
	}
}