using System.Collections.Generic;
using System.Web.Mvc;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using SelectListItem = IssueTicketingSystem.Models.SelectListItem;

namespace IssueTicketingSystem.Services.CRUD.Interfaces
{
	public interface IPartService : IGenericService<PartQueryDto,PartCommandDto>
	{
	    string PartTypeSelectOptions();
	    string UnitSelectOptions();
	    string PartsOfPartTypeSelectOption(int idPartType);
	}
}