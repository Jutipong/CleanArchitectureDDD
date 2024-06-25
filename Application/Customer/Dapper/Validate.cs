namespace Application.Customer.Dapper;

public class Validate : AbstractValidator<CustomerDapperHandlerQuery>
{
    public Validate()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}
