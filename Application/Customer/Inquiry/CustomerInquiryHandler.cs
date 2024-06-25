namespace Application.Customer.Inquiry;

public class InquiryCustomerHandler : IRequestHandler<InquiryCustomerQuery, List<Entities.Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public InquiryCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Entities.Customer>> Handle(InquiryCustomerQuery request, CancellationToken token)
    {
        var customer = await _customerRepository.Inquiry(request.Name, token);
        return customer;
    }
}
