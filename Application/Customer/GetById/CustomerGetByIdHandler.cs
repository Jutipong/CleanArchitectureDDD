namespace Application.Customer.GetById;

public interface ICustomerGetByIdRepository
{
    Task<Entities.Customer?> CustomerGetById(Guid id, CancellationToken token);
}

internal sealed class CustomerGetByIdHandler : IRequestHandler<CustomerGetByIdQuery, Entities.Customer?>
{
    private readonly ICustomerGetByIdRepository _repo;

    public CustomerGetByIdHandler(ICustomerGetByIdRepository repo)
    {
        _repo = repo;
    }

    public async Task<Entities.Customer?> Handle(CustomerGetByIdQuery request, CancellationToken token)
    {
        var customer = await _repo.CustomerGetById(request.Id, token);
        return customer;
    }
}
