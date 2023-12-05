namespace Application.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Guid id) : IQuery;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.id).NotEmpty();
    }
}
