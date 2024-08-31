using Mapster;

namespace Application.Customer.Create;

public interface ICustomerCreateRepository
{
    Task<Guid> CreateCustomer(Entities.Customer customer, CancellationToken token);
}

internal sealed class CustomerCreateHandler : IRequestHandler<CustomerCreateRequest, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerCreateRepository _repo;

    public CustomerCreateHandler(IUnitOfWork unitOfWork, ICustomerCreateRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<Guid> Handle(CustomerCreateRequest req, CancellationToken token)
    {
        var customerId = await _repo.CreateCustomer(req.Adapt<Entities.Customer>(), token);

        await _unitOfWork.SaveChangesAsync(token);

        return customerId;
    }
}
