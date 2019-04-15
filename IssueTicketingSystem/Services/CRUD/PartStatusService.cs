using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class PartStatusService : GenericService<PartStatusQueryDto,PartStatusCommandDto,IPartStatusRepository,tbl_part_status>,IPartStatusService
	{
		public PartStatusService(IPartStatusRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public string PartStatusSelectOption()
	    {
	        var sli = Repository.PartStatusSelectOption();
            return DropDownCreator.Create(sli);
	    }
	}
}