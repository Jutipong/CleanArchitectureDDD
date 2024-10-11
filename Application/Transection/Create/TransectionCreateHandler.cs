using Application.Customer.Create;
using Mapster;

namespace Application.Transection.Create;

public interface ITransectionCreateRepository
{
    Task<Guid> CreateTransection(Entities.Customer customer, CancellationToken token);
}

internal sealed class TransectionCreateHandler(IUnitOfWork unitOfWork, ITransectionCreateRepository repo)
    : IRequestHandler<CustomerCreateRequest, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITransectionCreateRepository _repo = repo;

    public async Task<Guid> Handle(CustomerCreateRequest req, CancellationToken token)
    {
        var customerId = await _repo.CreateTransection(req.Adapt<Entities.Customer>(), token);

        await _unitOfWork.SaveChangesAsync(token);

        return customerId;
    }
}
