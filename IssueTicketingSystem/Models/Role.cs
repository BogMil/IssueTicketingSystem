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
    public class Role
    {
        public string Name { get; set; }
    }

    public class RoleQueryDto : Role
    {
        public int Id { get; set; }
    }

    public class RoleCommandDto : Role
    {
        public int id { get; set; }
    }

    public class RoleViewModel : GenericJqGridViewModel<RoleQueryDto> { }

    public class RoleOrderByPredicateCreator : GenericOrderByPredicateCreator<tbl_roles, RolePropertyMapper>
    {
        protected override Expression<Func<tbl_roles, dynamic>> GetDefaultOrderByColumn()
        {
            return x => x.Id;
        }
    }

    public class RoleWherePredicateCreator : GenericWherePredicateCreator<tbl_roles, RolePropertyMapper> { }

    public class RolePropertyMapper : GenericPropertyMapper<tbl_roles, RoleQueryDto>
    {
        public override Expression<Func<tbl_roles, dynamic>> GetPathInEfForDtoFieldExpression(string fieldName)
        {
            if (fieldName == GetDtoPropertyPathAsString(t => t.Id))
                return x => x.Id;
            if (fieldName == GetDtoPropertyPathAsString(t => t.Name))
                return x => x.Name;

            throw new Exception("Putem requesta je poslato nepostojece polje " + fieldName +
            "  Obezbediti da za svako polje iz QueryDto modela postoji odgovarajuce mapiranje u entity modelu (bazi).");
        }

    }

    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<tbl_roles, RoleQueryDto>();

            CreateMap<RoleCommandDto, tbl_roles>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.tbl_account, o => o.Ignore());

            CreateMap<PagedList<tbl_roles>, StaticPagedList<RoleQueryDto>>()
                .ConvertUsing<PagedListConverter<tbl_roles, RoleQueryDto>>();
        }
    }
}