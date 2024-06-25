using Domain.Interfaces.Customer;

namespace Infrastructure.Repository.Customer;

public class CustomerDeleteRepository(SqlContext sqlContext) : ICustomerDeleteRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public void DeleteCustomer(Guid id, CancellationToken token)
    {
        _dbContext.RemoveRange(_dbContext.Customer.Where(customer => customer.ID == id), token);
    }
}
