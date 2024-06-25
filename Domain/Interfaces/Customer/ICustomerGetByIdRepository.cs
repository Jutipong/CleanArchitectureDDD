namespace Domain.Interfaces.Customer;

public interface ICustomerGetByIdRepository
{
    Task<Entities.Customer?> CustomerGetById(Guid id, CancellationToken token);
}
