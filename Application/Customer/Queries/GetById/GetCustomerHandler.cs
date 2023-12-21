namespace Application.Customer.Queries.GetById;

internal sealed class GetCustomerHandler : IRequestHandlerResult<GetCustomerByIdQuery>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerById(request.Id, cancellationToken);

        return customer?.Count == 0
            ? Result.Failure(Error.NullValue)
            : Result.Success(customer);
    }
}

