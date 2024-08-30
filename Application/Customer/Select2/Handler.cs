namespace Application.Customer.Select2;

public interface IRepository
{
    Task<List<Response>> Inquiry(string? name, int? pageSize, CancellationToken cancellationToken);
}

public class Handler(IRepository repo) : IRequestHandler<Request, List<Response>>
{
    private readonly IRepository _repo = repo;

    public async Task<List<Response>> Handle(Request req, CancellationToken token)
    {
        var customer = await _repo.Inquiry(req.Name, req.PageSize, token);
        return customer;
    }
}
