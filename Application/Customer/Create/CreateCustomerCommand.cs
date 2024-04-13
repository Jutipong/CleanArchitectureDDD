namespace Application.Customer.Create;

public record CreateCustomerCommand : ICommand<Guid>
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public int? Age { get; init; } = null;
    public string Email { get; init; } = string.Empty;
}
