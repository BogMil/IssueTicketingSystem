using System;
using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class PartRepository : 
			IssueTicketingSystemRepository<tbl_part,PartOrderByPredicateCreator,PartWherePredicateCreator>,
		IPartRepository
	{
	    public PartRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_part entity)
		{
			return entity.Id;		
		}

	    protected override void ShouldDeleteEntity(tbl_part entity)
	    {
	        if(entity.tbl_replacement.Count > 0)
                throw new Exception("Selected part is used as replacemend. To delete it, first delete all replacement associated with it.");
	    }

	    public List<SelectListItem> PartsOfPartTypeSelectOptions(int idPartType)
	    {
	        return Db.tbl_part_types
	            .Where(x => x.Id == idPartType)
	            .SelectMany(x => x.tbl_part)
	            .Select(x=> new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
	            .ToList();
        }
	}
}