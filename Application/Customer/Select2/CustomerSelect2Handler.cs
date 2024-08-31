namespace Application.Customer.Select2;

public interface ICustomerSelect2Repository
{
    Task<List<CustomerSelect2Response>> Inquiry(string? name, int? pageSize, CancellationToken cancellationToken);
}

public class CustomerSelect2Handler(ICustomerSelect2Repository repo)
    : IRequestHandler<CustomerSelect2Request, List<CustomerSelect2Response>>
{
    private readonly ICustomerSelect2Repository _repo = repo;

    public async Task<List<CustomerSelect2Response>> Handle(CustomerSelect2Request req, CancellationToken token)
    {
        var customer = await _repo.Inquiry(req.Name, req.PageSize, token);
        return customer;
    }
}
