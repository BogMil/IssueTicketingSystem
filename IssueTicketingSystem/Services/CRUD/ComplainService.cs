using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class ComplainService : GenericService<ComplainQueryDto,ComplainCommandDto,IComplainRepository,tbl_complain>,IComplainService
	{
		public ComplainService(IComplainRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
	}
}