namespace Application.Customer.Select2;

public record Request(string? Name, int? PageSize) : IRequest<List<Response>>;
