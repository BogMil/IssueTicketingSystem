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
    public class Repairment
    {
        public decimal Quantity { get; set; }
        public int IdComplainIssue { get; set; }
        public int IdPart { get; set; }
        public string Remark { get; set; }
    }

    public class RepairmentQueryDto : Repairment
    {
        public int Id { get; set; }
        public string PartType { get; set; }
        public string Part { get; set; }

    }

    public class RepairmentCommandDto : Repairment
    {
        public int id { get; set; }
    }

    public class RepairmentViewModel : GenericJqGridViewModel<RepairmentQueryDto> { }

    public class RepairmentOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_repairment, RepairmentPropertyMapper>
    {
        protected override Expression<Func<tbl_repairment, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class RepairmentWherePredicateCreator : GenericWherePredicateCreator<tbl_repairment, RepairmentPropertyMapper> { }

    public class RepairmentPropertyMapper : GenericPropertyMapper<tbl_repairment, RepairmentQueryDto>
    {
        public override Expression<Func<tbl_repairment, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Quantity))
                return x => x.Quantity;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdComplainIssue))
                return x => x.IdComplainIssue;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdPart))
                return x => x.IdPart;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Remark))
                return x => x.Remark;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class RepairmentEditSelectValues
    {
        public int IdPart { get; set; }
        public int IdPartType { get; set; }
    }

    public class RepairmentMappingProfile : Profile
    {
        public RepairmentMappingProfile()
        {
            CreateMap<tbl_repairment, RepairmentQueryDto>()
                .ForMember(d => d.Part, o => o.MapFrom(s => s.tbl_part.Name))
                .ForMember(d => d.PartType, o => o.MapFrom(s => s.tbl_part.tbl_part_types.Name));

            CreateMap<tbl_repairment, RepairmentEditSelectValues>()
                .ForMember(d => d.IdPart,o=>o.MapFrom(s=>s.IdPart))
                .ForMember(d => d.IdPartType, o=>o.MapFrom(s=>s.tbl_part.IdPartType));

            CreateMap<RepairmentCommandDto, tbl_repairment>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_complain_issue, o => o.Ignore())
                .ForMember(d => d.tbl_part, o => o.Ignore());

            CreateMap<PagedList<tbl_repairment>, StaticPagedList<RepairmentQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_repairment, RepairmentQueryDto>>();
        }
    }
}