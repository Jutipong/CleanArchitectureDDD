namespace Application.Customer.Dapper;

public record CustomerDapperRequest(string Name) : IRequest<Result<List<Entities.Customer>>>;
