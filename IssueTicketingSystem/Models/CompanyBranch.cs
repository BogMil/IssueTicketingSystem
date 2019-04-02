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
    public class CompanyBranch
    {
        public int IdCompany { get; set; }
        public int IdBranch { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public bool Active { get; set; }
    }

    public class CompanyBranchQueryDto : CompanyBranch
    {
        public int Id { get; set; }
        public string Branch { get; set; }
    }

    public class CompanyBranchCommandDto : CompanyBranch
    {
        public int id { get; set; }
    }

    public class CompanyBranchViewModel : GenericJqGridViewModel<CompanyBranchQueryDto> { }

    public class CompanyBranchOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_company_branch, CompanyBranchPropertyMapper>
    {
        protected override Expression<Func<tbl_company_branch, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class CompanyBranchWherePredicateCreator : GenericWherePredicateCreator<tbl_company_branch, CompanyBranchPropertyMapper> { }

    public class CompanyBranchPropertyMapper : GenericPropertyMapper<tbl_company_branch, CompanyBranchQueryDto>
    {
        public override Expression<Func<tbl_company_branch, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdCompany))
                return x => x.IdCompany;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdBranch))
                return x => x.IdBranch;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Address))
                return x => x.Address;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Contact))
                return x => x.Contact;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Active))
                return x => x.Active;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class CompanyBranchMappingProfile : Profile
    {
        public CompanyBranchMappingProfile()
        {
            CreateMap<tbl_company_branch, CompanyBranchQueryDto>()
                .ForMember(d => d.Branch, o=>o.MapFrom(s=>$"{s.tbl_branch.tbl_location.tbl_region.tbl_state.Name}, " +
                                                          $"{s.tbl_branch.tbl_location.tbl_region.Name}, " +
                                                          $"{s.tbl_branch.tbl_location.Name}, " +
                                                          $"{s.tbl_branch.Name}"));

            CreateMap<CompanyBranchCommandDto, tbl_company_branch>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_branch, o => o.Ignore())
                .ForMember(d => d.tbl_company, o => o.Ignore())
                .ForMember(d => d.tbl_complain, o => o.Ignore());



            CreateMap<PagedList<tbl_company_branch>, StaticPagedList<CompanyBranchQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_company_branch, CompanyBranchQueryDto>>();
        }
    }

    
}