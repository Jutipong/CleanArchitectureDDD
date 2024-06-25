namespace Application.Customer.GetById;

public record CustomerGetByIdQuery(Guid Id) : IRequest<Entities.Customer>;
