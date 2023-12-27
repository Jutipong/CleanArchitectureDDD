using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Databases.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CustomerRepository(SqlContext db) : RepositoryBase<Customer>(db), ICustomerRepository
{
    private readonly SqlContext _db = db;

    public async Task<Guid> CreateCustomer(Customer customer, CancellationToken cancellationToken)
    {
        customer.ID = Guid.NewGuid();
        await _db.Customer.AddAsync(customer, cancellationToken);

        return customer.ID;
    }

    public async Task<List<Customer>> Inquiry(string name, CancellationToken cancellationToken)
    {
        var customers = await _db.Customer
             .Where(customer => string.IsNullOrWhiteSpace(name) || name.Contains(customer.Name!))
             .AsNoTracking()
             .ToListAsync(cancellationToken);

        return customers;
    }

    public async Task<Customer?> GetCustomerById(Guid id, CancellationToken cancellationToken)
    {
        var customers = await _db.Customer
            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        return customers;
    }

    //public async Task<bool> UpdateCustomer(Customer customer, CancellationToken cancellationToken)
    //{
    //    var customerDb = await _db.Customer.FirstOrDefaultAsync(x => x.ID == customer.ID, cancellationToken);
    //    if(customerDb != null)
    //    {
    //        customerDb.Code = customer.Code;
    //        customerDb.Name = customer.Name;
    //        customerDb.Email = customer.Email;
    //        customerDb.Age = customer.Age;

    //        return true;
    //    }

    //    return false;
    //}

    public void DeleteCustomer(Guid id, CancellationToken cancellationToken)
    {
        _db.RemoveRange(_db.Customer.Where(customer => customer.ID == id));
    }


    //ef
    public async Task<List<Customer>> MackCustomerDataEf(CancellationToken cancellationToken)
    {
        // generate thread sleep 10sec
        var customer = await _db.Database.SqlQuery<Customer>($"Select * From Customer")
                                         .ToListAsync(cancellationToken);

        return customer;
    }

    // dapper
    public async Task<List<Customer>> MackCustomerDataDapper1(CancellationToken cancellationToken)
    {
        // generate thread sleep 10sec
        var customer = await _db.Database.SqlQuery<Customer>($"Select * From Customer")
                                         .ToListAsync(cancellationToken);

        Thread.Sleep(10000);

        return customer;
    }

    // dapper
    public async Task<List<Customer>> MackCustomerDataDapper2(CancellationToken cancellationToken)
    {
        // generate thread sleep 30sec
        var customer = await _db.Database.SqlQuery<Customer>($"Select * From Customer")
                                         .ToListAsync(cancellationToken);

        Thread.Sleep(10000);

        return customer;
    }
}