using Domain.Interfaces.Customer;
using Mapster;

namespace Application.Customer.Create;

internal sealed class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerCreateRepository _repo;

    public CustomerCreateHandler(IUnitOfWork unitOfWork, ICustomerCreateRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<Guid> Handle(CustomerCreateCommand req, CancellationToken token)
    {
        var customerId = await _repo.CreateCustomer(req.Adapt<Entities.Customer>(), token);

        await _unitOfWork.SaveChangesAsync(token);

        return customerId;
    }
}
