namespace Application.Customer.Inquiry;

internal class InquiryCustomerHandler(ICustomerRepository customerRepository, IProducerService producerService)
    : IRequestHandlerResult<InquiryCustomerQuery>
{
    public async Task<Result> Handle(InquiryCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.Inquiry(request.Name, cancellationToken);

        await producerService.ProduceAsync("topic", "message");

        return customer.Count != 0 ? Result.Failure(Error.NullValue) : Result.Success(customer);
    }
}
