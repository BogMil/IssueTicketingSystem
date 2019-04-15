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
    public class ReplacementService : GenericService<ReplacementQueryDto, ReplacementCommandDto, IReplacementRepository, tbl_replacement>, IReplacementService
    {
        public ReplacementService(IReplacementRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public StaticPagedList<ReplacementQueryDto> ReplacementsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties,
            string filters)
        {
            Repository.CustomWherePredicate = (x) => x.IdComplainIssue == idComplainIssue;
            var entities = Repository.Filter(pager, filters, orderByProperties);

            return Mapper.Map<IPagedList<tbl_replacement>, StaticPagedList<ReplacementQueryDto>>((PagedList<tbl_replacement>)entities);
        }

        public ReplacementEditSelectValues GetReplacementEditSelectValues(int idReplacement)
        {
            var entity = Repository.Find(idReplacement);
            return Mapper.Map<tbl_replacement, ReplacementEditSelectValues>(entity);
        }
    }
}