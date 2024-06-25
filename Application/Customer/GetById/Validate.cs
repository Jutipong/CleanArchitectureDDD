namespace Application.Customer.GetById;

public class Validate : AbstractValidator<GetCustomerByIdQuery>
{
    public Validate()
    {
        RuleFor(r => r.Id).NotEmpty();
    }
}
