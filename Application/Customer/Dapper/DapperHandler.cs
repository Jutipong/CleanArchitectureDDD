namespace Application.Customer.TestMockData;

internal class DapperHandler : IRequestHandler<DapperHandlerQuery, Result<List<Entities.Customer>>>
{
    private readonly ICustomerRepository _customerRepository;

    public DapperHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<List<Entities.Customer>>> Handle(DapperHandlerQuery request, CancellationToken token)
    {
        // user ef
        var customers = new List<Entities.Customer>();

        customers.AddRange(await _customerRepository.MackCustomerDataEf(token));

        // user dapper
        var customerDapper1 = _customerRepository.MackCustomerDataDapper1(token);
        var customerDapper2 = _customerRepository.MackCustomerDataDapper2(token);
        await Task.WhenAll(customerDapper1, customerDapper2);

        customers.AddRange(customerDapper1.Result);
        customers.AddRange(customerDapper2.Result);

        var result = Result.Success(customers);
        return result;
    }
}
