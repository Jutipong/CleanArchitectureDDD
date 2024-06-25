using Domain.Interfaces.Customer;

namespace Infrastructure.Repository.Customer;

public class CustomerInquiryRepository(SqlContext sqlContext) : ICustomerInquiryRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<List<Entities.Customer>> Inquiry(string name, CancellationToken token)
    {
        var customers = await _dbContext
            .Customer.Where(customer => string.IsNullOrWhiteSpace(name) || name.Contains(customer.Name!))
            .AsNoTracking()
            .ToListAsync(token);

        return customers;
    }
}
