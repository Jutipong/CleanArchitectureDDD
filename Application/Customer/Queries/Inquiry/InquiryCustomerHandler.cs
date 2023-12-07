

namespace Application.Customer.Queries.Inquiry;
internal class InquiryCustomerHandler : IQueryHandler<InquiryCustomerQuery>
{
    private readonly ICustomerRepository _customerRepository;

    public InquiryCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(InquiryCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.Inquiry(request.Name, cancellationToken);
        return Result.Success(customer);
    }
}
