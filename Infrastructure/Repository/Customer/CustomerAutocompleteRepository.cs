using Application.Customer.Autocomplete;
using Infrastructure.Extensions;

namespace Infrastructure.Repository.Customer;

public class CustomerAutocompleteRepository(SqlContext sqlContext) : ICustomerAutocompleteRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<List<CustomerAutocompleteResponse>> Inquiry(CustomerAutocompleteRequest payload, CancellationToken token)
    {
        var result = await _dbContext
            .Customer.Where(r => payload.IdInit == null || payload.IdInit!.Contains(r.ID))
            .Where(customer => string.IsNullOrWhiteSpace(payload.TextSearch) || customer.Name!.Contains(payload.TextSearch))
            .Select(r => new CustomerAutocompleteResponse { Id = r.ID, Text = r.Name! })
            .ToPageAsync(1, payload.PageSize ?? 10, token);

        return result.Items;
    }
}
