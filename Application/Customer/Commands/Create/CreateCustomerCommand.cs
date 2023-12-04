namespace Application.Customer.Commands.Create;

public class CreateCustomerCommand : ICommand<Guid>
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 99;
    public string Email { get; set; } = string.Empty;
}

public class validator : AbstractValidator<CreateCustomerCommand>
{
    public validator()
    {
        RuleFor(r => r.Code).NotEmpty();
        RuleFor(r => r.Name).NotEmpty();
    }
}