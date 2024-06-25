namespace Application.Customer.Delete;

public record CustomerDeleteCommand(Guid Id) : IRequest<bool>;
