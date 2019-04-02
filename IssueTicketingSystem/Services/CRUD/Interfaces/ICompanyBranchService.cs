using System.Web.Mvc;
using GenericCSR.Service;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface ICompanyBranchService : IGenericService<CompanyBranchQueryDto,CompanyBranchCommandDto>
	{
	}
}