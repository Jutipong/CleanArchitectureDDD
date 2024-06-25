namespace Domain.Interfaces.Customer;

public interface ICustomerUpdateRepository
{
    Task<bool> UpdateCustomer(Entities.Customer customer, CancellationToken token);
}
