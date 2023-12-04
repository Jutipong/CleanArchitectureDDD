namespace Application.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Guid? id) : IValidate<Guid>;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.id).NotEmpty();
    }
}
