namespace Application.Customer.Delete;

public class Validate : AbstractValidator<CustomerDeleteCommand>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
