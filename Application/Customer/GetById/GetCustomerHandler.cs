namespace Application.Customer.GetById;

internal sealed class GetCustomerHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerByIdQuery>
{
    public async Task<Result> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetCustomerById(request.Id, cancellationToken);

        return customer is null ? Result.Failure(Error.DataNotFound) : Result.Success(customer);
    }
}
