namespace Application.Customer.Commands.Create;

internal sealed class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
{
    //private readonly ICustomerRepository _customerRepository;

    //public CreateCustomerHandler(ICustomerRepository customerRepository)
    //{
    //    _customerRepository = customerRepository;
    //}

    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        //var obj = request.Adapt<CustomerDto>();
        //var customer = await _customerRepository.CreateCustomer(obj);
        //if (customer != null)
        //{
        //    return Result.Failure(Error.NullValue);
        //}

        //return Result.Success(customer);

        return Result.Success(new CustomerEntities());
    }
}
