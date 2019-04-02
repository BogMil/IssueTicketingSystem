using System.Web.Mvc;
using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class CompanyBranchService : GenericService<CompanyBranchQueryDto,CompanyBranchCommandDto,ICompanyBranchRepository,tbl_company_branch>,ICompanyBranchService
	{
		public CompanyBranchService(ICompanyBranchRepository repository, IMapper mapper, IBranchRepository branchRepository) : base(repository, mapper)
		{
		}
	}
}