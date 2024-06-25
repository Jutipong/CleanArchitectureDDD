namespace Application.Customer.Create;

public class Validate : AbstractValidator<CustomerCreateCommand>
{
    public Validate()
    {
        RuleFor(r => r.Code).NotEmpty();
        RuleFor(r => r.Name).NotEmpty();
    }
}
