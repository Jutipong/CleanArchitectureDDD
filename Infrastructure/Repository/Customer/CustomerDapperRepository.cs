using Dapper;
using Domain.Interfaces.Customer;
using Infrastructure.Abstractions.Dapper;

namespace Infrastructure.Repository.Customer;

public class CustomerDapperRepository(IDapperConnection dapperContext, SqlContext sqlContext) : ICustomerDapperRepository
{
    private readonly IDapperConnection _dapperContext = dapperContext;
    private readonly SqlContext _dbContext = sqlContext;

    //ef
    public async Task<List<Entities.Customer>> MackCustomerDataEf(CancellationToken token)
    {
        // generate thread sleep 10sec
        var customer = await _dbContext.Database.SqlQuery<Entities.Customer>($"Select * From Customer").ToListAsync(token);

        //call store procedure with 2 param id and name
        // var id = new SqlParameter("@Id", 1);
        // var name = new SqlParameter("@Name", "Test");
        // var customer = await _dbContext.Database.SqlQuery<Entities.Customer>("GetCustomer @Id, @Name", id, name).ToListAsync(token);

        return customer;
    }

    // dapper
    public async Task<List<Entities.Customer>> MackCustomerDataDapper1(CancellationToken token)
    {
        using var connection = _dapperContext.CreateConnection();

        const string SQL = """ SELECT * FROM Customer """;

        var query = await connection.QueryAsync<Entities.Customer>(SQL, token);

        var customers = query.ToList();

        return customers;
    }

    // dapper
    public async Task<List<Entities.Customer>> MackCustomerDataDapper2(CancellationToken token)
    {
        using var connection = _dapperContext.CreateConnection();

        const string SQL = """ SELECT * FROM Customer """;

        var query = await connection.QueryAsync<Entities.Customer>(SQL, token);

        var customers = query.ToList();

        return customers;
    }
}
