namespace Application.Customer.Create;

public class CreateCustomerCommand : IRequestResult
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public int? Age { get; init; } = null;
    public string Email { get; init; } = string.Empty;
}

public class Validate : AbstractValidator<CreateCustomerCommand>
{
    public Validate()
    {
        RuleFor(r => r.Code).NotEmpty();
        RuleFor(r => r.Name).NotEmpty();
    }
}
