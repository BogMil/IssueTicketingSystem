using System;
using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class TypeOfComplainRepository : 
			IssueTicketingSystemRepository<tbl_type_of_complain,TypeOfComplainOrderByPredicateCreator,TypeOfComplainWherePredicateCreator>,
		ITypeOfComplainRepository
	{
	    public TypeOfComplainRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_type_of_complain entity)
		{
			return entity.Id;		
		}

	    public List<SelectListItem> ProfessionSelectOptions(int idServiceEngineer)
	    {
	        var listOfEngineersProfessions = ListOfEngineersProfessions(idServiceEngineer);
	        return Db.tbl_type_of_complain
	            .Where(x => x.Active)
	            .Where(x=>!listOfEngineersProfessions.Contains(x.Id))
	            .OrderBy(x => x.Name)
	            .Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Profession})
	            .ToList();
	    }

	    public List<SelectListItem> TypeOfComplainSelectOptions()
	    {
	        return Db.tbl_type_of_complain
	            .Where(x => x.Active)
	            .OrderBy(x => x.Name)
	            .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name })
	            .ToList();
        }

	    private List<int> ListOfEngineersProfessions(int idServiceEngineer)
	    {
	        var engineer = Db.tbl_service_engineer.Find(idServiceEngineer);
	        return engineer == null
	            ? new List<int>()
	            : engineer
	                .tbl_engineer_profession
	                .Select(x => x.tbl_type_of_complain.Id)
	                .ToList();
	    }

	    protected override void ShouldDeleteEntity(tbl_type_of_complain entity)
	    {
	        if(entity.tbl_complain.Count>0)
                throw new Exception("There are complains with type of selected complain type. In order to delete it, first delete all complains with type = selected type");
	    }
	}
}