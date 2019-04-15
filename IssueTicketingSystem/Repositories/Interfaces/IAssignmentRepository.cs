using GenericCSR.Repository;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.Repositories.Interfaces
{
	public interface IAssignmentRepository : IGenericRepository<tbl_assigned_service_engineer_to_issue>
	{
	}
}