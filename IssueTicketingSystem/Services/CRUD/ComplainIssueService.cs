using AutoMapper;
using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD
{
	public class ComplainIssueService : GenericService<ComplainIssueQueryDto,ComplainIssueCommandDto,IComplainIssueRepository,tbl_complain_issue>,IComplainIssueService
	{
	    private IComplainService _complainService;
		public ComplainIssueService(IComplainIssueRepository repository, IMapper mapper, IComplainService complainService) : base(repository, mapper)
		{
		    _complainService = complainService;
		}
	}
}