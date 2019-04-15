using AutoMapper;
using GenericCSR;
using GenericCSR.Service;
using GenericCSR.Sorter;
using IssueTicketingSystem.Models;
using IssueTicketingSystem.Repositories.Interfaces;
using IssueTicketingSystem.Services.CRUD.Interfaces;
using PagedList;

namespace IssueTicketingSystem.Services.CRUD
{
	public class VendorPaymentService : GenericService<VendorPaymentQueryDto,VendorPaymentCommandDto,IVendorPaymentRepository,tbl_vendor_payment>,IVendorPaymentService
	{
		public VendorPaymentService(IVendorPaymentRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

	    public StaticPagedList<VendorPaymentQueryDto> VendorPaymentsOfComplainIssue(int idComplainIssue, Pager pager, OrderByProperties orderByProperties,
	        string filters)
	    {
	        Repository.CustomWherePredicate = x => x.IdIssue == idComplainIssue;

	        var entities = Repository.Filter(pager, filters, orderByProperties);
	        return Mapper.Map<IPagedList<tbl_vendor_payment>, StaticPagedList<VendorPaymentQueryDto>>((PagedList<tbl_vendor_payment>)entities);
	    }
	}
}