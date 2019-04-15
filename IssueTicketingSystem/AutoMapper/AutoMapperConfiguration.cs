using AutoMapper;
using IssueTicketingSystem.Models;

namespace IssueTicketingSystem.AutoMapper
{
    public class AutoMapperConfiguration 
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration
            (
                cfg =>
                {
                    cfg.AddProfile<VendorMappingProfile>();
                    cfg.AddProfile<PartTypeMappingProfile>();
                    cfg.AddProfile<UnitMappingProfile>();
                    cfg.AddProfile<PartMappingProfile>();
                    cfg.AddProfile<PartStatusMappingProfile>();
                    cfg.AddProfile<ServiceEngineerMappingProfile>();
                    cfg.AddProfile<TypeOfComplainMappingProfile>();
                    cfg.AddProfile<EngineerProfessionMappingProfile>();
                    cfg.AddProfile<StateMappingProfile>();
                    cfg.AddProfile<RegionMappingProfile>();
                    cfg.AddProfile<LocationMappingProfile>();
                    cfg.AddProfile<BranchMappingProfile>();
                    cfg.AddProfile<RoleMappingProfile>();
                    cfg.AddProfile<AccountMappingProfile>();
                    cfg.AddProfile<CompanyMappingProfile>();
                    cfg.AddProfile<IssueStatusMappingProfile>();
                    cfg.AddProfile<PaymentStatusMappingProfile>();
                    cfg.AddProfile<ComplainMappingProfile>();
                    cfg.AddProfile<CompanyBranchMappingProfile>();
                    cfg.AddProfile<ComplainIssueMappingProfile>();
                    cfg.AddProfile<AssignmentMappingProfile>();
                    cfg.AddProfile<ReplacementMappingProfile>();
                    cfg.AddProfile<RepairmentMappingProfile>();
                    cfg.AddProfile<VendorPaymentMappingProfile>();
                    
                }
            );
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}