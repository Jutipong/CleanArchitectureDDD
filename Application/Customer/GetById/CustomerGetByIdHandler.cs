namespace Application.Customer.GetById;

internal sealed class GetCustomerHandler : IRequestHandler<GetCustomerByIdQuery, Entities.Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Entities.Customer?> Handle(GetCustomerByIdQuery request, CancellationToken token)
    {
        var customer = await _customerRepository.GetCustomerById(request.Id, token);

        return customer;
    }
}
