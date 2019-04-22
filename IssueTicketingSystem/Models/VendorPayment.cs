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
    public class VendorPayment
    {
        public decimal Amount { get; set; }
        public int IdPaymentStatus { get; set; }
        public int IdIssue { get; set; }
        public string Remark { get; set; }
        public int IdVendor { get; set; }
        public bool PayedByCash { get; set; }
    }

    public class VendorPaymentQueryDto : VendorPayment
    {
        public int Id { get; set; }
        public string PaymentStatus { get; set; }
        public string Vendor { get; set; }

    }

    public class VendorPaymentCommandDto : VendorPayment
    {
        public int id { get; set; }
    }

    public class VendorPaymentViewModel : GenericJqGridViewModel<VendorPaymentQueryDto> { }

    public class VendorPaymentOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_vendor_payment, VendorPaymentPropertyMapper>
    {
        protected override Expression<Func<tbl_vendor_payment, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class VendorPaymentWherePredicateCreator : GenericWherePredicateCreator<tbl_vendor_payment, VendorPaymentPropertyMapper> { }

    public class VendorPaymentPropertyMapper : GenericPropertyMapper<tbl_vendor_payment, VendorPaymentQueryDto>
    {
        public override Expression<Func<tbl_vendor_payment, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Amount))
                return x => x.Amount;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdPaymentStatus))
                return x => x.IdPaymentStatus;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdIssue))
                return x => x.IdIssue;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Remark))
                return x => x.Remark;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdVendor))
                return x => x.IdVendor;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class VendorPaymentMappingProfile : Profile
    {
        public VendorPaymentMappingProfile()
        {
            CreateMap<tbl_vendor_payment, VendorPaymentQueryDto>()
                .ForMember(d => d.Vendor, o => o.MapFrom(s => s.tbl_vendor != null ? s.tbl_vendor.Name : "FMS"))
                .ForMember(d => d.PaymentStatus, o => o.MapFrom(s => s.tbl_payment_status.Name));


            CreateMap<VendorPaymentCommandDto, tbl_vendor_payment>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_complain_issue, o => o.Ignore())
                .ForMember(d => d.tbl_payment_status, o => o.Ignore())
                .ForMember(d => d.tbl_vendor, o => o.Ignore());

            CreateMap<PagedList<tbl_vendor_payment>, StaticPagedList<VendorPaymentQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_vendor_payment, VendorPaymentQueryDto>>();
        }
    }
}