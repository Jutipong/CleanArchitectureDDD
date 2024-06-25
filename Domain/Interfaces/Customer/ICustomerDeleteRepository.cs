namespace Domain.Interfaces.Customer;

public interface ICustomerDeleteRepository
{
    void DeleteCustomer(Guid id, CancellationToken token);
}
