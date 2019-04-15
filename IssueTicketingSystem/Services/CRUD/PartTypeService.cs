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

	    public string PartTypeSelectOptions()
	    {
	        var sli = Repository.PartTypeSelectOptions();
	        return DropDownCreator.CreateNullable(sli, "-");
	    }

	    public string PartTypeThatHavePartsSelectOption()
	    {
	        var sli = Repository.PartTypeThatHavePartsSelectOption();
	        return DropDownCreator.CreateNullable(sli, "-");
        }
	}
}