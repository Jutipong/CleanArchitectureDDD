namespace Application.Customer.Delete;

public record CustomerDeleteRequest(Guid Id) : IRequest<bool>;
