namespace Application.Customer.TestMockData;

public class Validate : AbstractValidator<DapperHandlerQuery>
{
    public Validate()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}
