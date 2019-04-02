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
	}
}