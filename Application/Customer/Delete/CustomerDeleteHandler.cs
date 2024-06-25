namespace Application.Customer.Delete;

internal sealed class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public CustomerDeleteHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
    {
        _customerRepository.DeleteCustomer(request.Id, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
