using System.Collections.Generic;
using System.Linq;
using GenericCSR;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class CompanyRepository : 
			IssueTicketingSystemRepository<tbl_company,CompanyOrderByPredicateCreator,CompanyWherePredicateCreator>,
		ICompanyRepository
	{
	    public CompanyRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_company entity)
		{
			return entity.Id;		
		}

	    public List<SelectListItem> CompanySelectOptions()
	    {
	        return Db.tbl_company
	            .Where(x=>x.Active)
	            .OrderBy(x => x.Name)
	            .Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name})
	            .ToList();

	    }
	}
}