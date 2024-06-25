using Domain.Interfaces.Customer;

namespace Infrastructure.Repository.Customer;

internal class CustomerUpdateRepository(SqlContext sqlContext) : ICustomerUpdateRepository
{
    private readonly SqlContext _dbContext = sqlContext;

    public async Task<bool> UpdateCustomer(Entities.Customer customer, CancellationToken cancellationToken)
    {
        var customerDb = await _dbContext.Customer.FirstOrDefaultAsync(x => x.ID == customer.ID, cancellationToken);
        if (customerDb != null)
        {
            customerDb.Code = customer.Code;
            customerDb.Name = customer.Name;
            customerDb.Email = customer.Email;
            customerDb.Age = customer.Age;

            return true;
        }

        return false;
    }
}
