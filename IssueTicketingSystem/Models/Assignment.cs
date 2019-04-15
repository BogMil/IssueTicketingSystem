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
    public class Assignment
    {
        public int IdServiceEngineer { get; set; }
        public int IdIssue { get; set; }
        public string Remark { get; set; }
        public bool PreventedFromWorking { get; set; }
    }

    public class AssignmentQueryDto : Assignment
    {
        public int Id { get; set; }
        public string ServiceEngineer {get;set;}
        public string Vendor { get; set; }
    }

    public class AssignmentCommandDto : Assignment
    {
        public int id { get; set; }
    }

    public class AssignmentViewModel : GenericJqGridViewModel<AssignmentQueryDto> { }

    public class AssignmentOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_assigned_service_engineer_to_issue, AssignmentPropertyMapper>
    {
        protected override Expression<Func<tbl_assigned_service_engineer_to_issue, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class AssignmentWherePredicateCreator : GenericWherePredicateCreator<tbl_assigned_service_engineer_to_issue, AssignmentPropertyMapper> { }

    public class AssignmentPropertyMapper : GenericPropertyMapper<tbl_assigned_service_engineer_to_issue, AssignmentQueryDto>
    {
        public override Expression<Func<tbl_assigned_service_engineer_to_issue, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdServiceEngineer))
                return x => x.IdServiceEngineer;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdIssue))
                return x => x.IdIssue;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Remark))
                return x => x.Remark;
            if (fieldName == GetDtoPropertyPathAsString(t => t.PreventedFromWorking))
                return x => x.PreventedFromWorking;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class AssignmentEditSelectValues
    {
        public int IdServiceEngineer { get; set; }
        public int? IdVendor { get; set; }
    }

    public class AssignmentMappingProfile : Profile
    {
        public AssignmentMappingProfile()
        {
            CreateMap<tbl_assigned_service_engineer_to_issue, AssignmentQueryDto>()
                .ForMember(d => d.ServiceEngineer,
                    o => o.MapFrom(s =>
                        $"{s.tbl_service_engineer.LastName} {s.tbl_service_engineer.MiddleName} {s.tbl_service_engineer.FirstName}"))
                .ForMember(d => d.Vendor, o => o.MapFrom(s => s.tbl_service_engineer.IdVendor !=null ? s.tbl_service_engineer.tbl_vendor.Name : "FMS"));

            CreateMap<AssignmentCommandDto, tbl_assigned_service_engineer_to_issue>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_complain_issue, o => o.Ignore())
                .ForMember(d => d.tbl_service_engineer, o => o.Ignore());

            CreateMap<PagedList<tbl_assigned_service_engineer_to_issue>, StaticPagedList<AssignmentQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_assigned_service_engineer_to_issue, AssignmentQueryDto>>();

            CreateMap<tbl_assigned_service_engineer_to_issue, AssignmentEditSelectValues>()
                .ForMember(d=>d.IdVendor,o=>o.MapFrom(s=>s.tbl_service_engineer.IdVendor));
        }
    }
}