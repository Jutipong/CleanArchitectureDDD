namespace Application.Customer.Queries.GetById;

internal sealed class GetCustomerHandler : IQueryHandler<GetCustomerByIdQuery>
{
    //private readonly ICustomerRepository _customerRepository;

    //public GetCustomerHandler(ICustomerRepository customerRepository)
    //{
    //    _customerRepository = customerRepository;
    //}

    public async Task<Result> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        //var customer = await _customerRepository.GetCustomerById(request.id);

        //if (customer is null)
        //{
        //    return Result.Failure<Guid>(Error.NullValue);
        //}

        //return Result.Success(customer);

        return Result.Success(new CustomerEntities());
    }
}