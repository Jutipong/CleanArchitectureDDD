namespace Application.Customer.GetById;

internal sealed class CustomerGetByIdHandler : IRequestHandler<CustomerGetByIdQuery, Entities.Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerGetByIdHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Entities.Customer?> Handle(CustomerGetByIdQuery request, CancellationToken token)
    {
        var customer = await _customerRepository.GetCustomerById(request.Id, token);

        return customer;
    }
}
