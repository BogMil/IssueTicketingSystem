using System.Collections.Generic;
using System.Linq;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class RoleRepository : 
			IssueTicketingSystemRepository<tbl_roles,RoleOrderByPredicateCreator,RoleWherePredicateCreator>,
		IRoleRepository
	{
	    public RoleRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_roles entity)
		{
			return entity.Id;		
		}

	    public List<SelectListItem> RoleSelectOptions()
	    {
	        return Db.tbl_roles
	            .OrderBy(x => x.Name)
	            .Select(x => new SelectListItem {Text = x.Name, Value = x.Id.ToString()})
	            .ToList();
	    }
	}
}