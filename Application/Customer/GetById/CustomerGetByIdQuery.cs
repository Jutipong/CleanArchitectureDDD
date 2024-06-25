namespace Application.Customer.GetById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<Entities.Customer>;
