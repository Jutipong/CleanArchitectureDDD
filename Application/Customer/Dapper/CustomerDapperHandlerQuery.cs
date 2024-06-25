namespace Application.Customer.TestMockData;

public record CustomerDapperHandlerQuery(string Name) : IRequest<Result<List<Entities.Customer>>>;
