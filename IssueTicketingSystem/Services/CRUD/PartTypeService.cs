using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class PartTypeService : GenericService<PartTypeQueryDto,PartTypeCommandDto,IPartTypeRepository,tbl_part_types>,IPartTypeService
	{
		public PartTypeService(IPartTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
	}
}