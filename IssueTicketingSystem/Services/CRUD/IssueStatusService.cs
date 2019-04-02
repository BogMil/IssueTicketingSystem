using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class IssueStatusService : GenericService<IssueStatusQueryDto,IssueStatusCommandDto,IIssueStatusRepository,tbl_issue_status>,IIssueStatusService
	{
		public IssueStatusService(IIssueStatusRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
	}
}