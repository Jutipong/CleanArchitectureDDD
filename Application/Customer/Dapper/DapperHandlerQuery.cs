namespace Application.Customer.TestMockData;

public record DapperHandlerQuery(string Name) : IRequest<Result<List<Entities.Customer>>>;
