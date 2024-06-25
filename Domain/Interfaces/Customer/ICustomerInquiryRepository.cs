namespace Domain.Interfaces.Customer;

public interface ICustomerInquiryRepository
{
    Task<List<Entities.Customer>> Inquiry(string name, CancellationToken cancellationToken);
}
