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
    public class ComplainIssue
    {
        public string Subject { get; set; }
        public int IdComplain { get; set; }
        public int IdIssueStatus { get; set; }
        public string Description { get; set; }
        public bool Replaced { get; set; }
        public string Remark { get; set; }
    }

    public class ComplainIssueQueryDto : ComplainIssue
    {
        public int Id { get; set; }
        public string DateFixed { get; set; }
        public string IssueStatus { get; set; }
        public string ComplainType { get; set; }
    }

    public class ComplainIssueCommandDto : ComplainIssue
    {
        public int id { get; set; }
        public DateTime DateFixed { get; set; }

    }

    public class ComplainIssueViewModel : GenericJqGridViewModel<ComplainIssueQueryDto> { }

    public class ComplainIssueOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_complain_issue, ComplainIssuePropertyMapper>
    {
        protected override Expression<Func<tbl_complain_issue, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class ComplainIssueWherePredicateCreator : GenericWherePredicateCreator<tbl_complain_issue, ComplainIssuePropertyMapper> { }

    public class ComplainIssuePropertyMapper : GenericPropertyMapper<tbl_complain_issue, ComplainIssueQueryDto>
    {
        public override Expression<Func<tbl_complain_issue, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Subject))
                return x => x.Subject;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdComplain))
                return x => x.IdComplain;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdIssueStatus))
                return x => x.IdIssueStatus;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Description))
                return x => x.Description;
            if (fieldName == GetDtoPropertyPathAsString(t => t.DateFixed))
                return x => x.DateFixed;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Replaced))
                return x => x.Replaced;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Remark))
                return x => x.Remark;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class ComplainIssueMappingProfile : Profile
    {
        public ComplainIssueMappingProfile()
        {
            CreateMap<tbl_complain_issue, ComplainIssueQueryDto>()
                .ForMember(d => d.DateFixed, o => o.MapFrom(s => s.DateFixed.GetDateString()))
                .ForMember(d => d.IssueStatus, o => o.MapFrom(s => s.tbl_issue_status.Name))
                .ForMember(d => d.ComplainType, o => o.MapFrom(s => s.tbl_complain.tbl_type_of_complain.Name));


            CreateMap<ComplainIssueCommandDto, tbl_complain_issue>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_additional_payment, o => o.Ignore())
                .ForMember(d => d.tbl_assigned_service_engineer_to_issue, o => o.Ignore())
                .ForMember(d => d.tbl_complain, o => o.Ignore())
                .ForMember(d => d.tbl_issue_status, o => o.Ignore())
                .ForMember(d => d.tbl_repairment, o => o.Ignore())
                .ForMember(d => d.tbl_replacement, o => o.Ignore())
                .ForMember(d => d.tbl_vendor_payment, o => o.Ignore());

            CreateMap<PagedList<tbl_complain_issue>, StaticPagedList<ComplainIssueQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_complain_issue, ComplainIssueQueryDto>>();
        }
    }
}