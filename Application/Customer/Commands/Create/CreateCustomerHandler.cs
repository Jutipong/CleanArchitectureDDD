namespace Application.Customer.Commands.Create;

internal sealed class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerId = await _customerRepository.CreateCustomer(
            request.Adapt<Entities.Customer>(),
            cancellationToken);

        return Result.Success(customerId);
    }
}
