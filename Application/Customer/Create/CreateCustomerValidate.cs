namespace Application.Customer.Create;

public class Validate : AbstractValidator<CreateCustomerCommand>
{
    public Validate()
    {
        RuleFor(r => r.Code).NotEmpty();
        RuleFor(r => r.Name).NotEmpty();
    }
}
