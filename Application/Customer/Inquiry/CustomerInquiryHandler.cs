namespace Application.Customer.Inquiry;

public interface ICustomerInquiryRepository
{
    Task<List<Entities.Customer>> Inquiry(string? name, CancellationToken cancellationToken);
}

public class CustomerInquiryHandler(ICustomerInquiryRepository repo) : IRequestHandler<CustomerInquiryRequest, List<Entities.Customer>>
{
    private readonly ICustomerInquiryRepository _repo = repo;

    public async Task<List<Entities.Customer>> Handle(CustomerInquiryRequest request, CancellationToken token)
    {
        var customer = await _repo.Inquiry(request.Name, token);
        return customer;
    }
}
