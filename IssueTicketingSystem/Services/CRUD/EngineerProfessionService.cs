using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class EngineerProfessionService : GenericService<EngineerProfessionQueryDto,EngineerProfessionCommandDto,IEngineerProfessionRepository,tbl_engineer_profession>,IEngineerProfessionService
	{
		public EngineerProfessionService(IEngineerProfessionRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
	}
}