using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class CompanyBranchRepository : 
			IssueTicketingSystemRepository<tbl_company_branch,CompanyBranchOrderByPredicateCreator,CompanyBranchWherePredicateCreator>,
		ICompanyBranchRepository
	{
	    public CompanyBranchRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_company_branch entity)
		{
			return entity.Id;		
		}
	}
}