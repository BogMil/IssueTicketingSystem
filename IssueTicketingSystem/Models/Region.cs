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
    public class Region
    {
        public string Name { get; set; }
        public int IdState { get; set; }
    }

    public class RegionQueryDto : Region
    {
        public int Id { get; set; }
    }

    public class RegionCommandDto : Region
    {
        public int id { get; set; }
    }

    public class RegionViewModel : GenericJqGridViewModel<RegionQueryDto> { }

    public class RegionOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_region, RegionPropertyMapper>
    {
        protected override Expression<Func<tbl_region, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class RegionWherePredicateCreator : GenericWherePredicateCreator<tbl_region, RegionPropertyMapper> { }

    public class RegionPropertyMapper : GenericPropertyMapper<tbl_region, RegionQueryDto>
    {
        public override Expression<Func<tbl_region, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdState))
                return x => x.IdState;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class RegionMappingProfile : Profile
    {
        public RegionMappingProfile()
        {
            CreateMap<tbl_region, RegionQueryDto>();

            CreateMap<RegionCommandDto, tbl_region>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_location, o => o.Ignore())
                .ForMember(d => d.tbl_state, o => o.Ignore());

            CreateMap<PagedList<tbl_region>, StaticPagedList<RegionQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_region, RegionQueryDto>>();
        }
    }
}