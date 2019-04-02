using AutoMapper;
using GenericCSR;
using GenericCSR.Filter;
using GenericCSR.PropertyMapper;
using PagedList;
using System;
using System.Linq.Expressions;
using GenericCSR.Sorter;

namespace IssueTicketingSystem.Models
{
    public class IssueStatus
    {
        public string Name { get; set; }
    }

    public class IssueStatusQueryDto : IssueStatus
    {
        public int Id { get; set; }
    }

    public class IssueStatusCommandDto : IssueStatus
    {
        public int id { get; set; }
    }

    public class IssueStatusViewModel : GenericJqGridViewModel<IssueStatusQueryDto> { }

    public class IssueStatusOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_issue_status, IssueStatusPropertyMapper>
    {
        protected override Expression<Func<tbl_issue_status, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class IssueStatusWherePredicateCreator : GenericWherePredicateCreator<tbl_issue_status, IssueStatusPropertyMapper> { }

    public class IssueStatusPropertyMapper : GenericPropertyMapper<tbl_issue_status, IssueStatusQueryDto>
    {
        public override Expression<Func<tbl_issue_status, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class IssueStatusMappingProfile : Profile
    {
        public IssueStatusMappingProfile()
        {
            CreateMap<tbl_issue_status, IssueStatusQueryDto>();

            CreateMap<IssueStatusCommandDto, tbl_issue_status>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_complain_issue, o => o.Ignore());

            CreateMap<PagedList<tbl_issue_status>, StaticPagedList<IssueStatusQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_issue_status, IssueStatusQueryDto>>();
        }
    }
}