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
    public class Company
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Contact { get; set; }
    }

    public class CompanyQueryDto : Company
    {
        public int Id { get; set; }
    }

    public class CompanyCommandDto : Company
    {
        public int id { get; set; }
    }

    public class CompanyViewModel : GenericJqGridViewModel<CompanyQueryDto> { }

    public class CompanyOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_company, CompanyPropertyMapper>
    {
        protected override Expression<Func<tbl_company, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class CompanyWherePredicateCreator : GenericWherePredicateCreator<tbl_company, CompanyPropertyMapper> { }

    public class CompanyPropertyMapper : GenericPropertyMapper<tbl_company, CompanyQueryDto>
    {
        public override Expression<Func<tbl_company, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Active))
                return x => x.Active;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Contact))
                return x => x.Contact;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<tbl_company, CompanyQueryDto>();

            CreateMap<CompanyCommandDto, tbl_company>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_account, o => o.Ignore())
                .ForMember(d => d.tbl_company_branch, o => o.Ignore());

            CreateMap<PagedList<tbl_company>, StaticPagedList<CompanyQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_company, CompanyQueryDto>>();
        }
    }
}