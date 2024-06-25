namespace Application.Customer.Update;

public class CustomerUpdateCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public short? Age { get; init; }
    public string Email { get; init; } = string.Empty;
}
