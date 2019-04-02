using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class UnitService : GenericService<UnitQueryDto,UnitCommandDto,IUnitRepository,tbl_unit>,IUnitService
	{
		public UnitService(IUnitRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
	}
}