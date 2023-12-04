namespace Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Guid> GetCustomerById(Guid id);
}
