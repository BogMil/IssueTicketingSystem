using System.Collections.Generic;
using System.Web;
using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class StateService : GenericService<StateQueryDto,StateCommandDto,IStateRepository,tbl_state>,IStateService
	{
		public StateService(IStateRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public string StateSelectOptions()
	    {
	        var sli = Repository.StateSelectOptions();
	        return DropDownCreator.Create(sli);
	    }

	    public string NullableStateSelectOptions()
	    {
	        var sli = Repository.StateSelectOptions();
	        return DropDownCreator.CreateNullable(sli,"-");
	    }

	    public string NullableStateSelectOptionsForCustomersCompany(int idCompany)
	    {
	        List<SelectListItem> sli;
            if (HttpContext.Current.User.HasAnyOfRoles(CustomRoles.User, CustomRoles.Administrator))
	            sli = Repository.StateSelectOptions();
            else
                sli = Repository.StateSelectOptionsForCustomersCompany(idCompany);

            return DropDownCreator.CreateNullable(sli, "-");
        }
	}
}