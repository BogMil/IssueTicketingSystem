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
    public class Location
    {
        public string Name { get; set; }
        public int IdRegion { get; set; }
    }

    public class LocationQueryDto : Location
    {
        public int Id { get; set; }
    }

    public class LocationCommandDto : Location
    {
        public int id { get; set; }
    }

    public class LocationViewModel : GenericJqGridViewModel<LocationQueryDto> { }

    public class LocationOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_location, LocationPropertyMapper>
    {
        protected override Expression<Func<tbl_location, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class LocationWherePredicateCreator : GenericWherePredicateCreator<tbl_location, LocationPropertyMapper> { }

    public class LocationPropertyMapper : GenericPropertyMapper<tbl_location, LocationQueryDto>
    {
        public override Expression<Func<tbl_location, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdRegion))
                return x => x.IdRegion;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<tbl_location, LocationQueryDto>();

            CreateMap<LocationCommandDto, tbl_location>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_branch, o => o.Ignore())
                .ForMember(d => d.tbl_region, o => o.Ignore());

            CreateMap<PagedList<tbl_location>, StaticPagedList<LocationQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_location, LocationQueryDto>>();
        }
    }
}