using System.Collections.Generic;
using System.Linq;
using GenericCSR;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class BranchRepository : 
			IssueTicketingSystemRepository<tbl_branch,BranchOrderByPredicateCreator,BranchWherePredicateCreator>,
		IBranchRepository
	{
	    public BranchRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_branch entity)
		{
			return entity.Id;		
		}

	    public List<SelectListItem> BranchSelectOptions(int idLocation)
	    {
	        return Db.tbl_branch
	            .Where(x=>x.IdLocation==idLocation)
	            .Select(x=>new SelectListItem {Value = x.Id.ToString(), Text = x.Name})
	            .OrderBy(x=>x.Text)
	            .ToList();
	    }

	    public List<SelectListItem> BranchSelectOptionsForCustomersCompany(int idLocation, int idCompany)
	    {
	        return Db.tbl_company_branch
	            .Where(x => x.IdCompany == idCompany)
	            .Where(x => x.tbl_branch.IdLocation== idLocation)
	            .Where(x =>x.Active)
                .Select(x =>
	                new SelectListItem
	                {
	                    Text = x.tbl_branch.Name,
	                    Value = x.tbl_branch.Id.ToString()
	                })
	            .Distinct()
	            .OrderBy(x => x.Text)
	            .ToList();
        }
	}
}