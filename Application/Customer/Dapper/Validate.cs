namespace Application.Customer.Dapper;

public class Validate : AbstractValidator<CustomerDapperRequest>
{
    public Validate()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}
