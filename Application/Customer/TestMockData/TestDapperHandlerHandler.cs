namespace Application.Customer.TestMockData;

public record TestDapperHandlerQuery(string Name) : IRequestResult;

internal class TestMockDataHandler : IRequestHandlerResult<TestDapperHandlerQuery>
{
    private readonly ICustomerRepository _customerRepository;

    public TestMockDataHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(TestDapperHandlerQuery request, CancellationToken cancellationToken)
    {
        // user ef
        var customers = new List<Entities.Customer>();

        customers.AddRange(await _customerRepository.MackCustomerDataEf(cancellationToken));

        // user dapper
        var customerDapper1 = _customerRepository.MackCustomerDataDapper1(cancellationToken);
        var customerDapper2 = _customerRepository.MackCustomerDataDapper2(cancellationToken);
        await Task.WhenAll(customerDapper1, customerDapper2);

        customers.AddRange(customerDapper1.Result);
        customers.AddRange(customerDapper2.Result);

        return customers.Count == 0 ? Result.Failure(Error.DataNotFound) : Result.Success(customers);
    }
}
