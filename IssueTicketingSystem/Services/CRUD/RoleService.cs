using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class RoleService : GenericService<RoleQueryDto,RoleCommandDto,IRoleRepository,tbl_roles>,IRoleService
	{
		public RoleService(IRoleRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public string RoleSelectOptions()
	    {
	        var selectListItems = Repository.RoleSelectOptions();
	        return DropDownCreator.Create(selectListItems);

	    }
	}
}