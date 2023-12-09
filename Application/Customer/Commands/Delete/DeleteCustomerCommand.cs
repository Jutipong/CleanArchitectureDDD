namespace Application.Customer.Commands.Delete;

public record DeleteCustomerCommand(Guid id) : IRequestResult;
