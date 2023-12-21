namespace Application.Customer.Commands.Delete;

public record DeleteCustomerCommand(Guid Id) : IRequestResult;
