using System.Collections.Generic;
using System.Web.UI;
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
	public class RepairmentService : GenericService<RepairmentQueryDto,RepairmentCommandDto,IRepairmentRepository,tbl_repairment>,IRepairmentService
	{
		public RepairmentService(IRepairmentRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public StaticPagedList<RepairmentQueryDto> RepairmentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties,
	        string filters)
	    {
	        Repository.CustomWherePredicate = x => x.IdComplainIssue == idComplainIssue;

	        var entities = Repository.Filter(pager, filters, orderByProperties);

            return Mapper.Map<IPagedList<tbl_repairment>, StaticPagedList<RepairmentQueryDto>>((PagedList<tbl_repairment>) entities);
	    }

	    public RepairmentEditSelectValues GetRepairmentEditSelectValues(int idRepairment)
	    {
	        var entity = Repository.Find(idRepairment);
	        return Mapper.Map<tbl_repairment, RepairmentEditSelectValues>(entity);
	    }
	}
}