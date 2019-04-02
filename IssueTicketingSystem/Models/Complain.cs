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
    public class Complain
    {
        public string Status { get; set; }
        public int IdAccount { get; set; }
        public int IdTypeOfComplain { get; set; }
        public int IdCompanyBranch { get; set; }
        public string Aging { get; set; }
        public string Remark { get; set; }
    }

    public class ComplainQueryDto : Complain
    {
        public int Id { get; set; }
        public string RequstedDate { get; set; }
        public string ClosingDate { get; set; }
        public string CustomerWhoRaisedIssue { get; set; }
        public string TypeOfComplain { get; set; }
        public string Company { get; set; }
        public string CompanyBranch { get; set; }
    }

    public class ComplainCommandDto : Complain
    {
        public int id { get; set; }
        public DateTime RequstedDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }

    public class ComplainViewModel : GenericJqGridViewModel<ComplainQueryDto> { }

    public class ComplainOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_complain, ComplainPropertyMapper>
    {
        protected override Expression<Func<tbl_complain, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class ComplainWherePredicateCreator : GenericWherePredicateCreator<tbl_complain, ComplainPropertyMapper> { }

    public class ComplainPropertyMapper : GenericPropertyMapper<tbl_complain, ComplainQueryDto>
    {
        public override Expression<Func<tbl_complain, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.RequstedDate))
                return x => x.RequstedDate;
            if (fieldName == GetDtoPropertyPathAsString(t => t.ClosingDate))
                return x => x.ClosingDate;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Status))
                return x => x.Status;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdAccount))
                return x => x.IdAccount;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdTypeOfComplain))
                return x => x.IdTypeOfComplain;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdCompanyBranch))
                return x => x.IdCompanyBranch;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Aging))
                return x => x.Aging;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Remark))
                return x => x.Remark;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class ComplainMappingProfile : Profile
    {
        public ComplainMappingProfile()
        {
            CreateMap<tbl_complain, ComplainQueryDto>()
                .ForMember(d => d.Company, o => o.MapFrom(s => s.tbl_company_branch.tbl_company.Name))
                .ForMember(d => d.TypeOfComplain, o => o.MapFrom(s => s.tbl_type_of_complain.Name))
                .ForMember(d => d.CustomerWhoRaisedIssue,
                    o => o.MapFrom(s => $"{s.tbl_account.FirstName} {s.tbl_account.LastName}"))
                .ForMember(d => d.CompanyBranch, o => o.MapFrom(s =>
                    $"{s.tbl_company_branch.tbl_branch.tbl_location.tbl_region.tbl_state.Name}, " +
                    $"{s.tbl_company_branch.tbl_branch.tbl_location.tbl_region.Name}, " +
                    $"{s.tbl_company_branch.tbl_branch.tbl_location.Name}, " +
                    $"{s.tbl_company_branch.tbl_branch.Name}, " +
                    $"{s.tbl_company_branch.tbl_branch.Name}," +
                    $" {s.tbl_company_branch.Address}"));

            CreateMap<ComplainCommandDto, tbl_complain>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_account, o => o.Ignore())
                .ForMember(d => d.tbl_company_branch, o => o.Ignore())
                .ForMember(d => d.tbl_complain_issue, o => o.Ignore())
                .ForMember(d => d.tbl_type_of_complain, o => o.Ignore());


            CreateMap<PagedList<tbl_complain>, StaticPagedList<ComplainQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_complain, ComplainQueryDto>>();
        }
    }
}