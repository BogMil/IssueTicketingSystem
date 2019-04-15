using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class ComplainIssueService : GenericService<ComplainIssueQueryDto,ComplainIssueCommandDto,IComplainIssueRepository,tbl_complain_issue>,IComplainIssueService
	{
		public ComplainIssueService(IComplainIssueRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
	}
}