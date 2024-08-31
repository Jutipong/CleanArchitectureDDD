namespace Application.Customer.Autocomplete;

public class CustomerAutocompleteResponse
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Text { get; init; } = string.Empty;
}
