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
    public class Branch
    {
        public string Name { get; set; }
        public int IdLocation { get; set; }
    }

    public class BranchQueryDto : Branch
    {
        public int Id { get; set; }
    }

    public class BranchCommandDto : Branch
    {
        public int id { get; set; }
    }

    public class BranchViewModel : GenericJqGridViewModel<BranchQueryDto> { }

    public class BranchOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_branch, BranchPropertyMapper>
    {
        protected override Expression<Func<tbl_branch, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class BranchWherePredicateCreator : GenericWherePredicateCreator<tbl_branch, BranchPropertyMapper> { }

    public class BranchPropertyMapper : GenericPropertyMapper<tbl_branch, BranchQueryDto>
    {
        public override Expression<Func<tbl_branch, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdLocation))
                return x => x.IdLocation;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<tbl_branch, BranchQueryDto>();

            CreateMap<BranchCommandDto, tbl_branch>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_company_branch, o => o.Ignore())
                .ForMember(d => d.tbl_location, o => o.Ignore());

            CreateMap<PagedList<tbl_branch>, StaticPagedList<BranchQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_branch, BranchQueryDto>>();

            CreateMap<tbl_branch, CompanyBranchEditSelectValue>()
                .ForMember(d => d.IdBranch, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.IdLocation, o => o.MapFrom(s => s.tbl_location.Id))
                .ForMember(d => d.IdRegion, o => o.MapFrom(s => s.tbl_location.tbl_region.Id))
                .ForMember(d => d.IdState, o => o.MapFrom(s => s.tbl_location.tbl_region.tbl_state.Id));
        }
    }

    public class CompanyBranchEditSelectValue
    {
        public int IdBranch { get; set; }
        public int IdLocation { get; set; }
        public int IdRegion { get; set; }
        public int IdState { get; set; }
    }
}