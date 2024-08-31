using Application.Customer.Select2;
using Infrastructure.Extensions;

namespace Infrastructure.Repository.Customer;

public class Select2Repository(SqlContext sqlContext) : ICustomerSelect2Repository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<List<CustomerSelect2Response>> Inquiry(CustomerSelect2Request payload, CancellationToken token)
    {
        var result = await _dbContext
            .Customer.Where(r => payload.IdInit == null || payload.IdInit!.Contains(r.ID))
            .Where(customer => string.IsNullOrWhiteSpace(payload.TextSearch) || customer.Name!.Contains(payload.TextSearch))
            .Select(r => new CustomerSelect2Response { Id = r.ID, Text = r.Name! })
            .ToPageAsync(1, payload.PageSize ?? 10, token);

        return result.Items;
    }
}
