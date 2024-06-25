using Domain.Interfaces.Customer;

namespace Infrastructure.Repository.Customer;

public class CustomerGetByIdRepository(SqlContext sqlContext) : ICustomerGetByIdRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<Entities.Customer?> CustomerGetById(Guid id, CancellationToken token)
    {
        var customers = await _dbContext.Customer.FirstOrDefaultAsync(x => x.ID == id, token);
        return customers;
    }
}
