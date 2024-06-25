namespace Application.Customer.Inquiry;

public class CustomerInquiryHandler : IRequestHandler<CustomerInquiryQuery, List<Entities.Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerInquiryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Entities.Customer>> Handle(CustomerInquiryQuery request, CancellationToken token)
    {
        var customer = await _customerRepository.Inquiry(request.Name, token);
        return customer;
    }
}
