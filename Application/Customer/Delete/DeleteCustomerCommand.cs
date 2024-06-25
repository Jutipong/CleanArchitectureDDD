namespace Application.Customer.Delete;

public record DeleteCustomerCommand(Guid Id) : IRequest<bool>;
