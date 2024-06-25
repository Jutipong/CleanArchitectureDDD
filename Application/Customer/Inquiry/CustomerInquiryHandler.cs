using Domain.Interfaces.Customer;

namespace Application.Customer.Inquiry;

public class CustomerInquiryHandler : IRequestHandler<CustomerInquiryQuery, List<Entities.Customer>>
{
    private readonly ICustomerInquiryRepository _repo;

    public CustomerInquiryHandler(ICustomerInquiryRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Entities.Customer>> Handle(CustomerInquiryQuery request, CancellationToken token)
    {
        var customer = await _repo.Inquiry(request.Name, token);
        return customer;
    }
}
