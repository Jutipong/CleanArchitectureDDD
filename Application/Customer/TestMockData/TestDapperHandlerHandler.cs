namespace Application.Customer.TestMockData;

public record TestDapperHandlerQuery(string Name) : IRequest<Result<List<Entities.Customer>>>;

public class Validate : AbstractValidator<TestDapperHandlerQuery>
{
    public Validate()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}

internal class TestMockDataHandler(ICustomerRepository customerRepository)
    : IRequestHandler<TestDapperHandlerQuery, Result<List<Entities.Customer>>>
{
    public async Task<Result<List<Entities.Customer>>> Handle(TestDapperHandlerQuery request, CancellationToken cancellationToken)
    {
        // user ef
        var customers = new List<Entities.Customer>();

        customers.AddRange(await customerRepository.MackCustomerDataEf(cancellationToken));

        // user dapper
        var customerDapper1 = customerRepository.MackCustomerDataDapper1(cancellationToken);
        var customerDapper2 = customerRepository.MackCustomerDataDapper2(cancellationToken);
        await Task.WhenAll(customerDapper1, customerDapper2);

        customers.AddRange(customerDapper1.Result);
        customers.AddRange(customerDapper2.Result);

        var result = Result.Success(customers);
        return result;
    }
}
