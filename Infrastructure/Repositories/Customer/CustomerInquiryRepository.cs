using Application.Customer.Inquiry;

namespace Infrastructure.Repositories.Customer;

public class CustomerInquiryRepository(SqlContext sqlContext) : ICustomerInquiryRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<List<Entities.Customer>> Inquiry(string? name, CancellationToken token)
    {
        var customers = await _dbContext
            .Customer.Where(customer => string.IsNullOrWhiteSpace(name) || customer.Name!.Contains(name))
            .AsNoTracking()
            .ToListAsync(token);

        return customers;
    }
}
