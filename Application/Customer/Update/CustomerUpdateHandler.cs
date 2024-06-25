namespace Application.Customer.Update;

internal sealed class CustomerUpdateHandler : IRequestHandler<CustomerUpdateCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public CustomerUpdateHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerById(request.Id, cancellationToken);

        if (customer is null)
        {
            return false;
        }

        customer.Code = request.Code;
        customer.Name = request.Name;
        customer.Email = request.Email;
        customer.Age = request.Age;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
