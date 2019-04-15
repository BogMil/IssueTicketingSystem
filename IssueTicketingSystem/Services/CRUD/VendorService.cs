using AutoMapper;
using GenericCSR.Service;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;

namespace IssueTicketingSystem.Services.CRUD
{
	public class VendorService : GenericService<VendorQueryDto,VendorCommandDto,IVendorRepository,tbl_vendor>,IVendorService
	{
		public VendorService(IVendorRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public string VendorSelectOptions()
	    {
	        var sli=Repository.VendorSelectOptions();
	        return DropDownCreator.CreateNullable(sli, "FMS");
	    }

	    public string VendorToPaySelectOption(int idComplainIssue)
	    {
	        var sli = Repository.VendorToPaySelectOption(idComplainIssue);
	        return DropDownCreator.CreateNullable(sli, "-");
	    }
	}
}