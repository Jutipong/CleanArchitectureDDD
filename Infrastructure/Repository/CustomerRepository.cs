using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Databases.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    private readonly SqlContext _db;

    public CustomerRepository(SqlContext db) : base(db)
    {
        _db = db;
    }

    public async Task<Guid> CreateCustomer(Customer customer, CancellationToken cancellationToken)
    {
        await _db.Customer.AddAsync(customer, cancellationToken);

        return customer.ID;
    }

    public async Task<List<Customer>> Inquiry(string Name, CancellationToken cancellationToken)
    {
        var customers = await _db.Customer
             .Where(customer => string.IsNullOrWhiteSpace(Name) || Name.Contains(customer.Name!))
             .AsNoTracking()
             .ToListAsync(cancellationToken);

        return customers;
    }

    public async Task<List<Customer>> GetCustomerById(Guid id, CancellationToken cancellationToken)
    {
        List<Customer> customers = await _db.Customer
            .Where(x => x.ID == id)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return customers;
    }

    public void UpdateCustomer(Customer customer)
    {
        _db.Update(customer);
    }

    public void DelteCustomer(Guid id, CancellationToken cancellationToken)
    {
        var del = _db.Customer.FirstOrDefaultAsync(customer => customer.ID == id, cancellationToken);
        _db.Remove(del);
    }
}
