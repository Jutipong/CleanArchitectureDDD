using Domain.Dtos;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    Task<CustomerEntities> CreateCustomer(CustomerDto customer);
    Task<Guid?> GetCustomerById(Guid id);
}


