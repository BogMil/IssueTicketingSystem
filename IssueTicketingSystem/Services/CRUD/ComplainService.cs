using System.Web;
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
    public class ComplainService : GenericService<ComplainQueryDto, ComplainCommandDto, IComplainRepository, tbl_complain>, IComplainService
    {
        private readonly IComplainIssueRepository _complainIssueRepository;
        public ComplainService(IComplainRepository repository, IMapper mapper, IComplainIssueRepository complainIssueRepository) : base(repository, mapper)
        {
            _complainIssueRepository = complainIssueRepository;
        }

        public StaticPagedList<ComplainIssueQueryDto> IssuesOfComplain(int idComplain, Pager pager, OrderByProperties orderByProperties, string filters)
        {
            _complainIssueRepository.CustomWherePredicate = (x) => x.IdComplain == idComplain;
            var entities = _complainIssueRepository.Filter(pager, filters, orderByProperties);

            return Mapper.Map<IPagedList<tbl_complain_issue>, StaticPagedList<ComplainIssueQueryDto>>((PagedList<tbl_complain_issue>)entities);
        }

        public StaticPagedList<ComplainQueryDto> ComplainsOfCompany(Pager pager, OrderByProperties orderByProperties, string filters)
        {
            var idCompany = HttpContext.Current.User.GetIdCompany();
            if (HttpContext.Current.User.IsInRole(CustomRoles.Customer))
                Repository.CustomWherePredicate =
                    x => x.tbl_company_branch.IdCompany == idCompany;

            var entities = Repository.Filter(pager, filters, orderByProperties);

            return Mapper.Map<IPagedList<tbl_complain>, StaticPagedList<ComplainQueryDto>>((PagedList<tbl_complain>)entities);
        }

        public ComplainEditSelectValues GetEditSelectValues(int idComplain)
        {
            var esl = Repository.Find(idComplain);
            return Mapper.Map<tbl_complain, ComplainEditSelectValues>(esl);
        }


        public string GetRefreshedStatusForComplain(int idComplain)
        {
            return Repository.GetRefreshedStatusForComplain(idComplain);
        }
    }
}