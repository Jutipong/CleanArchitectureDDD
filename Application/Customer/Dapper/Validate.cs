namespace Application.Customer.TestMockData;

public class Validate : AbstractValidator<CustomerDapperHandlerQuery>
{
    public Validate()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}
