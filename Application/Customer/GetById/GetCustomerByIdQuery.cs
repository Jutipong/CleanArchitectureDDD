namespace Application.Customer.GetById;

public record GetCustomerByIdQuery(Guid Id) : IRequestResult;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
