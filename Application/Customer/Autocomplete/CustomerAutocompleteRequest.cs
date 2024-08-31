namespace Application.Customer.Autocomplete;

public class CustomerAutocompleteRequest : IRequest<List<CustomerAutocompleteResponse>>
{
    public string? TextSearch { get; init; }
    public List<Guid>? IdInit { get; init; }
    public int? PageSize { get; init; }
}
