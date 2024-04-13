namespace Application.Customer.GetById;

public record GetCustomerByIdQuery(Guid Id) : IQuery;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
