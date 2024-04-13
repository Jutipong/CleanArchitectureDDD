namespace Application.Customer.Create;

internal sealed class CreateCustomerHandler : IRequestHandlerResult<CreateCustomerCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerId = await _customerRepository.CreateCustomer(request.Adapt<Entities.Customer>(), cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(customerId);
    }
}
