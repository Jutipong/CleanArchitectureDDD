using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Guid> CreateCustomer(Customer customer, CancellationToken cancellationToken);

    //Task<bool> UpdateCustomer(Customer customer, CancellationToken cancellationToken);
    void DeleteCustomer(Guid id, CancellationToken cancellationToken);
    Task<Customer?> GetCustomerById(Guid id, CancellationToken cancellationToken);
    Task<List<Customer>> Inquiry(string name, CancellationToken cancellationToken);

    Task<List<Customer>> MackCustomerDataEf(CancellationToken cancellationToken);
    Task<List<Customer>> MackCustomerDataDapper1(CancellationToken cancellationToken);
    Task<List<Customer>> MackCustomerDataDapper2(CancellationToken cancellationToken);
}
