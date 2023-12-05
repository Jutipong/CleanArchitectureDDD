namespace Application.Customer.Commands.Update;

public class UpdateCustomerCommand : ICommand
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 99;
    public string Email { get; set; } = string.Empty;
}
