namespace Application.Customer.Delete;

public record DeleteCustomerCommand(Guid Id) : IRequestResult;
