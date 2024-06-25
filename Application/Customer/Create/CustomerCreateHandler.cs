using Mapster;

namespace Application.Customer.Create;

internal sealed class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(CreateCustomerCommand req, CancellationToken token)
    {
        var customerId = await _customerRepository.CreateCustomer(req.Adapt<Entities.Customer>(), token);

        await _unitOfWork.SaveChangesAsync(token);

        return customerId;
    }
}
