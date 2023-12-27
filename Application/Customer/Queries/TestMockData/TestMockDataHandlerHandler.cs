namespace Application.Customer.Queries.Inquiry;

public record TestMockDataHandlerQuery(string Name) : IRequestResult;

internal class TestMockDataHandler : IRequestHandlerResult<TestMockDataHandlerQuery>
{
    private readonly ICustomerRepository _customerRepository;

    public TestMockDataHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(TestMockDataHandlerQuery request, CancellationToken cancellationToken)
    {
        // user ef
        var customers = await _customerRepository.MackCustomerDataEf(cancellationToken);

        var customerDapper1 = _customerRepository.MackCustomerDataDapper1(cancellationToken);
        var customerDapper2 = _customerRepository.MackCustomerDataDapper2(cancellationToken);

        await Task.WhenAll(customerDapper1, customerDapper2);

        //var customers = new List<Entities.Customer>();


        //return customers.Count != 0
        //    ? Result.Success(customers)
        //    : Result.Failure(Error.DataNotFound);

        return Result.Success(customers);
    }
}
