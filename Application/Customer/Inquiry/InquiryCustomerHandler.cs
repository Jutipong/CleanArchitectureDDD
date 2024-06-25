namespace Application.Customer.Inquiry;

public class InquiryCustomerHandler(ICustomerRepository customerRepository) : IQueryHandler<InquiryCustomerQuery, List<Entities.Customer>>
{
    public async Task<Result<List<Entities.Customer>>> Handle(InquiryCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.Inquiry(request.Name, cancellationToken);
        return Result.Success(customer);
    }
}
