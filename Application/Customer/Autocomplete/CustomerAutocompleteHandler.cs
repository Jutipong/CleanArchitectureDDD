namespace Application.Customer.Autocomplete;

public interface ICustomerAutocompleteRepository
{
    Task<List<CustomerAutocompleteResponse>> Inquiry(CustomerAutocompleteRequest req, CancellationToken cancellationToken);
}

public class CustomerAutocompleteHandler(ICustomerAutocompleteRepository repo)
    : IRequestHandler<CustomerAutocompleteRequest, List<CustomerAutocompleteResponse>>
{
    private readonly ICustomerAutocompleteRepository _repo = repo;

    public async Task<List<CustomerAutocompleteResponse>> Handle(CustomerAutocompleteRequest req, CancellationToken token)
    {
        var customer = await _repo.Inquiry(req, token);
        return customer;
    }
}
