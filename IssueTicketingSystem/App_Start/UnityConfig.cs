using System.Web.Mvc;
using AutoMapper;
using IssueTicketingSystem.AutoMapper;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD;
using IssueTicketingSystem.Services.CRUD.Interfaces;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace IssueTicketingSystem
{
    public class UnityConfig
    {
        public static IMapper MapperInstance { get; set; }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IssueTicketingSystemEntities, IssueTicketingSystemEntities>(new HierarchicalLifetimeManager());
            #region AutoMapper
            container.RegisterInstance<IMapper>(new AutoMapperConfiguration().Configure().CreateMapper());

            MapperInstance = container.Resolve<IMapper>();
            #endregion

            container.RegisterType<IVendorRepository, VendorRepository>();
            container.RegisterType<IVendorService, VendorService>();

            container.RegisterType<IPartTypeRepository, PartTypeRepository>();
            container.RegisterType<IPartTypeService, PartTypeService>();

            container.RegisterType<IUnitRepository, UnitRepository>();
            container.RegisterType<IUnitService, UnitService>();

            container.RegisterType<IPartRepository, PartRepository>();
            container.RegisterType<IPartService, PartService>();

            container.RegisterType<IPartStatusRepository, PartStatusRepository>();
            container.RegisterType<IPartStatusService, PartStatusService>();

            container.RegisterType<IServiceEngineerRepository, ServiceEngineerRepository>();
            container.RegisterType<IServiceEngineerService, ServiceEngineerService>();

            container.RegisterType<ITypeOfComplainRepository, TypeOfComplainRepository>();
            container.RegisterType<ITypeOfComplainService, TypeOfComplainService>();

            container.RegisterType<IEngineerProfessionRepository, EngineerProfessionRepository>();
            container.RegisterType<IEngineerProfessionService, EngineerProfessionService>();

            container.RegisterType<IStateRepository, StateRepository>();
            container.RegisterType<IStateService, StateService>();

            container.RegisterType<IRegionRepository, RegionRepository>();
            container.RegisterType<IRegionService, RegionService>();

            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<ILocationService, LocationService>();

            container.RegisterType<IBranchRepository, BranchRepository>();
            container.RegisterType<IBranchService, BranchService>();

            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IRoleService, RoleService>();

            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountService, AccountService>();

            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<ICompanyService, CompanyService>();

            container.RegisterType<IIssueStatusRepository, IssueStatusRepository>();
            container.RegisterType<IIssueStatusService, IssueStatusService>();

            container.RegisterType<IPaymentStatusRepository, PaymentStatusRepository>();
            container.RegisterType<IPaymentStatusService, PaymentStatusService>();

            container.RegisterType<IComplainRepository, ComplainRepository>();
            container.RegisterType<IComplainService, ComplainService>();

            container.RegisterType<ICompanyBranchRepository, CompanyBranchRepository>();
            container.RegisterType<ICompanyBranchService, CompanyBranchService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
