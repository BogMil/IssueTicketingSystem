using System.Linq;
using AutoMapper;
using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD
{
	public class AssignmentService : GenericService<AssignmentQueryDto,AssignmentCommandDto,IAssignmentRepository,tbl_assigned_service_engineer_to_issue>,IAssignmentService
	{
		public AssignmentService(IAssignmentRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public StaticPagedList<AssignmentQueryDto> AssignmentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties,
	        string filters)
	    {
	        Repository.CustomWherePredicate = x => x.IdIssue == idComplainIssue;
	        var entities = Repository.Filter(pager, filters, orderByProperties);
	        
	        return Mapper.Map<IPagedList<tbl_assigned_service_engineer_to_issue>, StaticPagedList<AssignmentQueryDto>>((PagedList<tbl_assigned_service_engineer_to_issue>)entities);
	    }

	    public AssignmentEditSelectValues GetAssignmentEditSelectValues(int idAssignment)
	    {
	        var esl = Repository.Find(idAssignment);
	        return Mapper.Map<tbl_assigned_service_engineer_to_issue, AssignmentEditSelectValues>(esl);
	    }
	}
}