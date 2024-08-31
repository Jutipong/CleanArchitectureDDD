namespace Application.Customer.GetById;

public class Validate : AbstractValidator<CustomerGetByIdRequest>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
