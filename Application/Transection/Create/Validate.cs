namespace Application.Customer.Create;

public class Validate : AbstractValidator<CustomerCreateRequest>
{
    public Validate()
    {
        RuleFor(r => r.Code).NotEmpty();
        RuleFor(r => r.Name).NotEmpty();
    }
}
