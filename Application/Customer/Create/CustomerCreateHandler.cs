using Mapster;

namespace Application.Customer.Create;

internal sealed class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public CustomerCreateHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<Guid> Handle(CustomerCreateCommand req, CancellationToken token)
    {
        var customerId = await _customerRepository.CreateCustomer(req.Adapt<Entities.Customer>(), token);

        await _unitOfWork.SaveChangesAsync(token);

        return customerId;
    }
}
