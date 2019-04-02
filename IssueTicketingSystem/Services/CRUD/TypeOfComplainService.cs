using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class TypeOfComplainService : GenericService<TypeOfComplainQueryDto,TypeOfComplainCommandDto,ITypeOfComplainRepository,tbl_type_of_complain>,ITypeOfComplainService
	{
		public TypeOfComplainService(ITypeOfComplainRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public string TypeOfComplainSelectOptions()
	    {
	        var sli = Repository.TypeOfComplainSelectOptions();
	        return DropDownCreator.Create(sli);
	    }
	}
}