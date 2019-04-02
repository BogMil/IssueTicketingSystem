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
    public class ServiceEngineer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public string MiddleName { get; set; }
        public string ContactNumber { get; set; }
        public int? IdVendor { get; set; }
    }

    public class ServiceEngineerQueryDto : ServiceEngineer
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
    }

    public class ServiceEngineerCommandDto : ServiceEngineer
    {
        public int id { get; set; }
    }

    public class ServiceEngineerViewModel : GenericJqGridViewModel<ServiceEngineerQueryDto> { }

    public class ServiceEngineerOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_service_engineer, ServiceEngineerPropertyMapper>
    {
        protected override Expression<Func<tbl_service_engineer, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class ServiceEngineerWherePredicateCreator : GenericWherePredicateCreator<tbl_service_engineer, ServiceEngineerPropertyMapper> { }

    public class ServiceEngineerPropertyMapper : GenericPropertyMapper<tbl_service_engineer, ServiceEngineerQueryDto>
    {
        public override Expression<Func<tbl_service_engineer, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.FirstName))
                return x => x.FirstName;
            if (fieldName == GetDtoPropertyPathAsString(t => t.LastName))
                return x => x.LastName;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Active))
                return x => x.Active;
            if (fieldName == GetDtoPropertyPathAsString(t => t.MiddleName))
                return x => x.MiddleName;
            if (fieldName == GetDtoPropertyPathAsString(t => t.ContactNumber))
                return x => x.ContactNumber;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdVendor))
                return x => x.IdVendor;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class ServiceEngineerMappingProfile : Profile
    {
        public ServiceEngineerMappingProfile()
        {
            CreateMap<tbl_service_engineer, ServiceEngineerQueryDto>()
                .ForMember(d => d.Vendor, o => o.MapFrom(s => s.tbl_vendor!=null ? s.tbl_vendor.Name : "FMS"));

            CreateMap<ServiceEngineerCommandDto, tbl_service_engineer>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_assigned_service_engineer_to_issue, o => o.Ignore())
                .ForMember(d => d.tbl_assigned_service_engineer_to_issue1, o => o.Ignore())
                .ForMember(d => d.tbl_vendor, o => o.Ignore())
                .ForMember(d => d.tbl_engineer_profession, o => o.Ignore());

            CreateMap<PagedList<tbl_service_engineer>, StaticPagedList<ServiceEngineerQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_service_engineer, ServiceEngineerQueryDto>>();
        }
    }
}