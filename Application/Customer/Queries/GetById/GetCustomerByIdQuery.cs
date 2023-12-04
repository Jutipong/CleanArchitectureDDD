namespace Application.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Guid id) : ICommand;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.id).NotEmpty();
    }
}
