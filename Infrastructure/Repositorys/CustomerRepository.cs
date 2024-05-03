using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Databases.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    private readonly SqlContext _dbContext;
    private readonly IDapperConnection _dapperContext;

    public CustomerRepository(SqlContext dbContext, IDapperConnection dapperContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
        _dapperContext = dapperContext;
    }

    public async Task<Guid> CreateCustomer(Customer customer, CancellationToken cancellationToken)
    {
        customer.ID = Guid.NewGuid();
        await _dbContext.Customer.AddAsync(customer, cancellationToken);

        return customer.ID;
    }

    public async Task<List<Customer>> Inquiry(string name, CancellationToken cancellationToken)
    {
        var customers = await _dbContext
            .Customer.Where(customer => string.IsNullOrWhiteSpace(name) || name.Contains(customer.Name!))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return customers;
    }

    public async Task<Customer?> GetCustomerById(Guid id, CancellationToken cancellationToken)
    {
        var customers = await _dbContext.Customer.FirstOrDefaultAsync(x => x.ID == id, cancellationToken);

        return customers;
    }

    public async Task<bool> UpdateCustomerAsync(Customer customer, CancellationToken cancellationToken)
    {
        var customerDb = await _dbContext.Customer.FirstOrDefaultAsync(x => x.ID == customer.ID, cancellationToken);
        if (customerDb != null)
        {
            customerDb.Code = customer.Code;
            customerDb.Name = customer.Name;
            customerDb.Email = customer.Email;
            customerDb.Age = customer.Age;

            return true;
        }

        return false;
    }

    public void DeleteCustomer(Guid id, CancellationToken cancellationToken)
    {
        _dbContext.RemoveRange(_dbContext.Customer.Where(customer => customer.ID == id));
    }

    //ef
    public async Task<List<Customer>> MackCustomerDataEf(CancellationToken cancellationToken)
    {
        // generate thread sleep 10sec
        var customer = await _dbContext.Database.SqlQuery<Customer>($"Select * From Customer").ToListAsync(cancellationToken);

        return customer;
    }

    // dapper
    public async Task<List<Customer>> MackCustomerDataDapper1(CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.CreateConnection();

        const string SQL = """ SELECT * FROM Customer """;

        var query = await connection.QueryAsync<Customer>(SQL);

        var customers = query.ToList();

        return customers;
    }

    // dapper
    public async Task<List<Customer>> MackCustomerDataDapper2(CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.CreateConnection();

        const string SQL = """ SELECT * FROM Customer """;

        var query = await connection.QueryAsync<Customer>(SQL);

        var customers = query.ToList();

        return customers;
    }

    //test
    public async Task<(List<Customer>, int)> ToDataTableAsync(
        string sorting,
        string ordering,
        int page,
        int pageSize,
        CancellationToken cancellationToken
    )
    {
        return await _dbContext.Customer.OrderBy(sorting, ordering).ToPageAsync(page, pageSize, cancellationToken);
    }
}
