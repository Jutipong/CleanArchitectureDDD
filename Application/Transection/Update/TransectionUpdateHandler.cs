namespace Application.Transection.Update;

public interface ITransectionUpdateRepository
{
    Task UpdateTransection(CancellationToken cancellationToken);
}

internal sealed class TransectionUpdateHandler(ITransectionUpdateRepository repo) : IRequestHandler<TransectionUpdateRequest>
{
    private readonly ITransectionUpdateRepository _repo = repo;

    public async Task Handle(TransectionUpdateRequest req, CancellationToken cancellationToken)
    {
        await _repo.UpdateTransection(cancellationToken);
    }
}
