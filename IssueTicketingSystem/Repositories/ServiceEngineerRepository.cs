using System;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;

namespace IssueTicketingSystem.Repositories
{
	public class ServiceEngineerRepository : 
			IssueTicketingSystemRepository<tbl_service_engineer,ServiceEngineerOrderByPredicateCreator,ServiceEngineerWherePredicateCreator>,
		IServiceEngineerRepository
	{
	    public ServiceEngineerRepository(IssueTicketingSystemEntities context) : base(context)
	    {
	    }

	    protected override object GetPrimaryKey(tbl_service_engineer entity)
		{
			return entity.Id;		
		}

	    protected override void ShouldDeleteEntity(tbl_service_engineer entity)
	    {
	        if(entity.tbl_assigned_service_engineer_to_issue.Count > 0 ||
	           entity.tbl_assigned_service_engineer_to_issue1.Count > 0 || 
               entity.tbl_engineer_profession.Count > 0)

                throw new Exception(@"There are data like professions or assignment associated with service engineer you would like to delete.
                        It is required to first delete all associated data.
                        If engineer is not relevenat for you anymore uncheck 'active'");

        }
	}
}