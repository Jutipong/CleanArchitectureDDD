namespace Application.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Guid id) : ICommand<Guid>;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.id).NotEmpty();
    }
}
