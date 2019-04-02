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
    public class PaymentStatus
    {
        public string Name { get; set; }
    }

    public class PaymentStatusQueryDto : PaymentStatus
    {
        public int Id { get; set; }
    }

    public class PaymentStatusCommandDto : PaymentStatus
    {
        public int id { get; set; }
    }

    public class PaymentStatusViewModel : GenericJqGridViewModel<PaymentStatusQueryDto> { }

    public class PaymentStatusOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_payment_status, PaymentStatusPropertyMapper>
    {
        protected override Expression<Func<tbl_payment_status, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class PaymentStatusWherePredicateCreator : GenericWherePredicateCreator<tbl_payment_status, PaymentStatusPropertyMapper> { }

    public class PaymentStatusPropertyMapper : GenericPropertyMapper<tbl_payment_status, PaymentStatusQueryDto>
    {
        public override Expression<Func<tbl_payment_status, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class PaymentStatusMappingProfile : Profile
    {
        public PaymentStatusMappingProfile()
        {
            CreateMap<tbl_payment_status, PaymentStatusQueryDto>();

            CreateMap<PaymentStatusCommandDto, tbl_payment_status>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_additional_payment, o => o.Ignore())
                .ForMember(d => d.tbl_vendor_payment, o => o.Ignore());

            CreateMap<PagedList<tbl_payment_status>, StaticPagedList<PaymentStatusQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_payment_status, PaymentStatusQueryDto>>();
        }
    }
}