namespace Application.Customer.Update;

public class UpdateCustomerCommand : IRequestResult
{
    public Guid Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public short? Age { get; init; }
    public string Email { get; init; } = string.Empty;
}
