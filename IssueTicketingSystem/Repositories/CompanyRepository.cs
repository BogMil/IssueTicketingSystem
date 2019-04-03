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

	    public List<SelectListItem> CompanyBranchSelectOptionsForCustomersCompany(int idBranch, int idCompany)
	    {
	        return Db.tbl_company_branch
	            .Where(x => x.IdCompany == idCompany)
	            .Where(x => x.IdBranch == idBranch)
	            .Where(x =>x.Active)
	            .Select(x =>
	                new SelectListItem
	                {
	                    Text = x.Address,
	                    Value = x.Id.ToString()
	                })
	            .Distinct()
	            .OrderBy(x => x.Text)
	            .ToList();
        }
	}
}