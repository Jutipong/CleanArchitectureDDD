namespace Application.Customer.Delete;

public class Validate : AbstractValidator<DeleteCustomerCommand>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
