using System;
using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class PartTypeRepository : 
			IssueTicketingSystemRepository<tbl_part_types,PartTypeOrderByPredicateCreator,PartTypeWherePredicateCreator>,
		IPartTypeRepository
	{
	    public PartTypeRepository(IssueTicketingSystemEntities context) : base(context){}

	    protected override object GetPrimaryKey(tbl_part_types entity)
		{
			return entity.Id;		
		}

	    public List<SelectListItem> PartTypeSelectOptions()
	    {
	        return Db.tbl_part_types
	            .OrderBy(x=>x.Name)
	            .Select(x => new SelectListItem() {Text = x.Name, Value = x.Id.ToString()})
	            .ToList();
	    }

	    public List<SelectListItem> PartTypeThatHavePartsSelectOption()
	    {
	        return Db.tbl_part_types
	            .Where(x=>x.tbl_part.Count>0)
	            .OrderBy(x => x.Name)
	            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() })
	            .ToList();
        }

	    protected override void ShouldDeleteEntity(tbl_part_types entity)
	    {
	        if(entity.tbl_part.Count>0)
                throw new Exception("This part type has parts. In order to delete part type, first delete all parts");
	    }
	}
}