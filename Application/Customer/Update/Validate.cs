namespace Application.Customer.Update;

public class Validate : AbstractValidator<CustomerUpdateRequest>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
        RuleFor(r => r.Name).NotEmpty();
    }
}
