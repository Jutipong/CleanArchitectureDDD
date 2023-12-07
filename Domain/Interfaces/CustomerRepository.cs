using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    void CreateCustomer(Customer customer, CancellationToken cancellationToken);
    Task<List<Customer>> GetCustomerById(Guid id, CancellationToken cancellationToken);
    Task<List<Customer>> Inquiry(string Name, CancellationToken cancellationToken);
}


