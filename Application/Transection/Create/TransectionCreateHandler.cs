namespace Application.Transection.Create;

public interface ITransectionCreateRepository
{
    Task<Entities.Transection> CreateTransection(CancellationToken cancellationToken);
}

internal sealed class Handler(IUnitOfWork unitOfWork, ITransectionCreateRepository repo)
    : IRequestHandler<TransectionCreateRequest, Entities.Transection>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITransectionCreateRepository _repo = repo;

    public async Task<Entities.Transection> Handle(TransectionCreateRequest req, CancellationToken cancellationToken)
    {
        var transection = await _repo.CreateTransection(cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return transection;
    }
}
