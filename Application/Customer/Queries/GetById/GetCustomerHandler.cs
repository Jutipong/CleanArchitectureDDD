namespace Application.Customer.Queries.GetById;

internal sealed class GetCustomerHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerByIdQuery>
{
    public async Task<Result> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetCustomerById(
            request.id,
            cancellationToken);

        return customer?.Count == 0
            ? Result.Failure(Error.NullValue)
            : Result.Success(customer);
    }
}

