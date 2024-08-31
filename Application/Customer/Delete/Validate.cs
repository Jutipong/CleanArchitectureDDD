namespace Application.Customer.Delete;

public class Validate : AbstractValidator<CustomerDeleteRequest>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
