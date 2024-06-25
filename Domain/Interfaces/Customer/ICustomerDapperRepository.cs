namespace Domain.Interfaces.Customer;

public interface ICustomerDapperRepository
{
    Task<List<Entities.Customer>> MackCustomerDataEf(CancellationToken cancellationToken);
    Task<List<Entities.Customer>> MackCustomerDataDapper1(CancellationToken cancellationToken);
    Task<List<Entities.Customer>> MackCustomerDataDapper2(CancellationToken cancellationToken);
}
