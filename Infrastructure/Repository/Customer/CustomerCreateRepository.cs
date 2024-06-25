using Domain.Interfaces.Customer;

namespace Infrastructure.Repository.Customer;

public class CustomerCreateRepository(SqlContext sqlContext) : ICustomerCreateRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<Guid> CreateCustomer(Entities.Customer customer, CancellationToken cancellationToken)
    {
        customer.ID = Guid.NewGuid();
        await _dbContext.Customer.AddAsync(customer, cancellationToken);

        return customer.ID;
    }
}
