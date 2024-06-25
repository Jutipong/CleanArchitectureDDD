namespace Domain.Interfaces.Customer;

public interface ICustomerCreateRepository
{
    Task<Guid> CreateCustomer(Entities.Customer customer, CancellationToken token);
}
