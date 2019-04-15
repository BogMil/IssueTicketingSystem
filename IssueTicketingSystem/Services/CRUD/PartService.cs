using System.Collections.Generic;
using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class PartService : GenericService<PartQueryDto,PartCommandDto,IPartRepository,tbl_part>,IPartService
	{
	    private IPartTypeRepository _partTypeRepo;
	    private IUnitRepository _unitRepo;
	    public PartService(IPartRepository repository, IMapper mapper, IPartTypeRepository partTypeRepo, IUnitRepository unitRepo) : base(repository, mapper)
	    {
	        _partTypeRepo = partTypeRepo;
	        _unitRepo = unitRepo;
	    }

	    public string PartTypeSelectOptions()
	    {
	        var selectListItems = _partTypeRepo.PartTypeSelectOptions();
	        return DropDownCreator.Create(selectListItems);
	    }

	    public string UnitSelectOptions()
	    {
	        var selectListItems = _unitRepo.UnitSelectOptions();
	        return DropDownCreator.Create(selectListItems);
        }

	    public string PartsOfPartTypeSelectOption(int idPartType)
	    {
	        var sli = Repository.PartsOfPartTypeSelectOptions(idPartType);
	        return DropDownCreator.Create(sli);
	    }
	}
}