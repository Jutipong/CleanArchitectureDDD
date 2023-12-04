namespace Application.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Guid? id) : ICommand<Guid>;

public class Validator : AbstractValidator<GetCustomerByIdQuery>
{
    public Validator()
    {
        RuleFor(r => r.id).NotEmpty();
    }
}
