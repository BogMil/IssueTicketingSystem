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
    public class Replacement
    {
        public decimal Quantity { get; set; }
        public int IdComplainIssue { get; set; }
        public int IdPart { get; set; }
        public int IdPartStatus { get; set; }
        public string Remark { get; set; }
    }

    public class ReplacementQueryDto : Replacement
    {
        public int Id { get; set; }
        public string Part { get; set; }
        public string PartStatus{ get; set; }
        public string PartType{ get; set; }

    }

    public class ReplacementCommandDto : Replacement
    {
        public int id { get; set; }
    }

    public class ReplacementViewModel : GenericJqGridViewModel<ReplacementQueryDto> { }

    public class ReplacementOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_replacement, ReplacementPropertyMapper>
    {
        protected override Expression<Func<tbl_replacement, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class ReplacementWherePredicateCreator : GenericWherePredicateCreator<tbl_replacement, ReplacementPropertyMapper> { }

    public class ReplacementPropertyMapper : GenericPropertyMapper<tbl_replacement, ReplacementQueryDto>
    {
        public override Expression<Func<tbl_replacement, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Quantity))
                return x => x.Quantity;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdComplainIssue))
                return x => x.IdComplainIssue;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdPart))
                return x => x.IdPart;
            if (fieldName == GetDtoPropertyPathAsString(t => t.IdPartStatus))
                return x => x.IdPartStatus;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Remark))
                return x => x.Remark;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class ReplacementEditSelectValues
    {
        public int IdPartType { get; set; }
        public int IdPart { get; set; }
    }

    public class ReplacementMappingProfile : Profile
    {
        public ReplacementMappingProfile()
        {
            CreateMap<tbl_replacement, ReplacementQueryDto>()
                .ForMember(d => d.Part, o => o.MapFrom(s => s.tbl_part.Name))
                .ForMember(d => d.PartType, o => o.MapFrom(s => s.tbl_part.tbl_part_types.Name))
                .ForMember(d => d.PartStatus, o => o.MapFrom(s => s.tbl_part_status.Name));

            CreateMap<tbl_replacement, ReplacementEditSelectValues>()
                .ForMember(x => x.IdPart, o => o.MapFrom(x => x.IdPart))
                .ForMember(x => x.IdPartType, o => o.MapFrom(x => x.tbl_part.IdPartType));



            CreateMap<ReplacementCommandDto, tbl_replacement>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_complain_issue, o => o.Ignore())
                .ForMember(d => d.tbl_part_status, o => o.Ignore())
                .ForMember(d => d.tbl_part, o => o.Ignore());

            CreateMap<PagedList<tbl_replacement>, StaticPagedList<ReplacementQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_replacement, ReplacementQueryDto>>();
        }
    }
}