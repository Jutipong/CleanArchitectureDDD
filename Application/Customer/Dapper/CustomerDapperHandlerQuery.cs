namespace Application.Customer.Dapper;

public record CustomerDapperHandlerQuery(string Name) : IRequest<Result<List<Entities.Customer>>>;
