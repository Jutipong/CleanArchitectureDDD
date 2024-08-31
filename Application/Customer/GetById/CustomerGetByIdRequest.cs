namespace Application.Customer.GetById;

public record CustomerGetByIdRequest(Guid Id) : IRequest<Entities.Customer>;
