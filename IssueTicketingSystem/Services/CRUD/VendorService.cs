using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class VendorService : GenericService<VendorQueryDto,VendorCommandDto,IVendorRepository,tbl_vendor>,IVendorService
	{
	    private readonly IComplainIssueRepository _complainIssueRepository;
		public VendorService(IVendorRepository repository, IMapper mapper, IComplainIssueRepository complainIssueRepository) : base(repository, mapper)
		{
		    _complainIssueRepository = complainIssueRepository;
		}

	    public string VendorSelectOptions()
	    {
	        var sli=Repository.VendorThatHaveEngineersSelectOptions();
	        return DropDownCreator.CreateNullable(sli, "FMS");
	    }

	    public string VendorToPaySelectOption(int idComplainIssue)
	    {
	        var sli = Repository.VendorToPaySelectOption(idComplainIssue);
	        return DropDownCreator.CreateNullable(sli, "-");
	    }

	    public string VendorThatCanFixComplainIssueSelectOptions(int idComplainIssue)
	    {
	        var issue = _complainIssueRepository.Find(idComplainIssue);
	        var idTypeOfComplain = issue.tbl_complain.IdTypeOfComplain;
	        var sli = Repository.VendorThatCanFixComplainTypeSelectOptions(idTypeOfComplain);

            return DropDownCreator.CreateNullable(sli, "-");
        }
	}
}