using Domain.Interfaces.Customer;

namespace Application.Customer.Dapper;

internal class CustomerDapperHandler : IRequestHandler<CustomerDapperHandlerQuery, Result<List<Entities.Customer>>>
{
    private readonly ICustomerDapperRepository _repo;

    public CustomerDapperHandler(ICustomerDapperRepository repo)
    {
        _repo = repo;
    }

    public async Task<Result<List<Entities.Customer>>> Handle(CustomerDapperHandlerQuery request, CancellationToken token)
    {
        // user ef
        var customers = new List<Entities.Customer>();

        customers.AddRange(await _repo.MackCustomerDataEf(token));

        // user dapper
        var customerDapper1 = _repo.MackCustomerDataDapper1(token);
        var customerDapper2 = _repo.MackCustomerDataDapper2(token);
        await Task.WhenAll(customerDapper1, customerDapper2);

        customers.AddRange(customerDapper1.Result);
        customers.AddRange(customerDapper2.Result);

        var result = Result.Success(customers);
        return result;
    }
}
