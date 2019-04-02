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
    public class Vendor
    {
        public string BancAccountNumber { get; set; }
        public string IFSC { get; set; }
        public bool Active { get; set; }
        public string ContactNumber { get; set; }
        public string Name { get; set; }

    }

    public class VendorQueryDto : Vendor
    {
        public int Id { get; set; }
    }

    public class VendorCommandDto : Vendor
    {
        public int id { get; set; }
    }

    public class VendorViewModel : GenericJqGridViewModel<VendorQueryDto> { }

    public class VendorOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_vendor, VendorPropertyMapper>
    {
        protected override Expression<Func<tbl_vendor, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class VendorWherePredicateCreator : GenericWherePredicateCreator<tbl_vendor, VendorPropertyMapper> { }

    public class VendorPropertyMapper : GenericPropertyMapper<tbl_vendor, VendorQueryDto>
    {
        public override Expression<Func<tbl_vendor, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.BancAccountNumber))
                return x => x.BancAccountNumber;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IFSC))
                return x => x.IFSC;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Active))
                return x => x.Active;
            if (fieldName == GetDtoPropertyPathAsString(t => t.ContactNumber))
                return x => x.ContactNumber;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class VendorMappingProfile : Profile
    {
        public VendorMappingProfile()
        {
            CreateMap<tbl_vendor, VendorQueryDto>();

            CreateMap<VendorCommandDto, tbl_vendor>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(s => s.tbl_service_engineer, o => o.Ignore())
                .ForMember(s => s.tbl_vendor_payment, o => o.Ignore())
                .ForMember(s => s.tbl_additional_payment, o => o.Ignore());

            CreateMap<PagedList<tbl_vendor>, StaticPagedList<VendorQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_vendor, VendorQueryDto>>();
        }
    }
}