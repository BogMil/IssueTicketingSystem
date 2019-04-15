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
    public class Part
    {
        public string Name { get; set; }
        public int IdUnit { get; set; }
        public bool Active { get; set; }
        public int IdPartType { get; set; }
        public string Description { get; set; }
    }

    public class PartQueryDto : Part
    {
        public int Id { get; set; }
        public string PartType { get; set; }
        public string Unit { get; set; }
    }

    public class PartCommandDto : Part
    {
        public int id { get; set; }
    }

    public class PartViewModel : GenericJqGridViewModel<PartQueryDto> { }

    public class PartOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_part, PartPropertyMapper>
    {
        protected override Expression<Func<tbl_part, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class PartWherePredicateCreator : GenericWherePredicateCreator<tbl_part, PartPropertyMapper> { }

    public class PartPropertyMapper : GenericPropertyMapper<tbl_part, PartQueryDto>
    {
        public override Expression<Func<tbl_part, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdUnit))
                return x => x.IdUnit;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Active))
                return x => x.Active;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdPartType))
                return x => x.IdPartType;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Description))
                return x => x.Description;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class PartMappingProfile : Profile
    {
        public PartMappingProfile()
        {
            CreateMap<tbl_part, PartQueryDto>()
                .ForMember(d => d.PartType, o => o.MapFrom(s => s.tbl_part_types.Name))
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.tbl_unit.Name));

            CreateMap<PartCommandDto, tbl_part>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_part_types, o => o.Ignore())
                .ForMember(d => d.tbl_replacement, o => o.Ignore())
                .ForMember(d => d.tbl_repairment, o => o.Ignore())
                .ForMember(d => d.tbl_unit, o => o.Ignore());

            CreateMap<PagedList<tbl_part>, StaticPagedList<PartQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_part, PartQueryDto>>();
        }
    }
}