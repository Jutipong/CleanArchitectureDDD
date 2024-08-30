using Application.Customer.Inquiry;
using Application.Customer.Select2;
using Infrastructure.Extensions;

namespace Infrastructure.Repository.Customer;

public class Select2Repository(SqlContext sqlContext) : IRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<List<Response>> Inquiry(string? name, int? pageSize, CancellationToken token)
    {
        var result = await _dbContext
            .Customer.Where(customer => string.IsNullOrWhiteSpace(name) || customer.Name!.Contains(name))
            .Select(r => new Response { Id = r.ID, Text = r.Name! })
            .ToPageAsync(1, pageSize ?? 10, token);

        return result.Items;
    }
}
