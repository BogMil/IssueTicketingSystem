using System;
using System.Collections.Generic;
using System.Linq;
using GenericCSR;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class StateRepository : 
			IssueTicketingSystemRepository<tbl_state,StateOrderByPredicateCreator,StateWherePredicateCreator>,
		IStateRepository
	{
	    public StateRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_state entity)
		{
			return entity.Id;		
		}

	    protected override void ShouldDeleteEntity(tbl_state entity)
	    {
	        if (entity.tbl_region.Count > 0)
	            throw new Exception("State has regions.First delete regions");
        }

	    public List<SelectListItem> StateSelectOptions()
	    {
	        return Db.tbl_state
	            .Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()})
	            .Distinct()
	            .OrderBy(x => x.Text)
                .ToList();
	    }

	    public List<SelectListItem> StateSelectOptionsForCustomersCompany(int idCompany)
	    {
	        return Db.tbl_company_branch
	            .Where(x=>x.IdCompany==idCompany)
	            .Where(x =>x.Active)
	            .Select(x =>
	                new SelectListItem
	                {
	                    Text = x.tbl_branch.tbl_location.tbl_region.tbl_state.Name,
	                    Value = x.tbl_branch.tbl_location.tbl_region.tbl_state.Id.ToString()
	                })
	            .Distinct()
	            .OrderBy(x => x.Text)
	            .ToList();
	    }
	}
}