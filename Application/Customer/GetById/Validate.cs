namespace Application.Customer.GetById;

public class Validate : AbstractValidator<CustomerGetByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
