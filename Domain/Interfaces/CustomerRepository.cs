using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Guid> CreateCustomer(Customer customer, CancellationToken cancellationToken);
    void UpdateCustomer(Customer customer);
    void DelteCustomer(Guid id, CancellationToken cancellationToken);
    Task<List<Customer>> GetCustomerById(Guid id, CancellationToken cancellationToken);
    Task<List<Customer>> Inquiry(string Name, CancellationToken cancellationToken);
}


