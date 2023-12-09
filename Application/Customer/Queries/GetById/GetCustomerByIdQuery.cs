namespace Application.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Guid id) : IRequestResult;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.id).NotEmpty();
    }
}
