using Domain.Interfaces.Customer;

namespace Application.Customer.Update;

internal sealed class CustomerUpdateHandler : IRequestHandler<CustomerUpdateCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerUpdateRepository _customerUpdateRepository;
    private readonly ICustomerGetByIdRepository _customerGetByIdRepository;

    public CustomerUpdateHandler(
        IUnitOfWork unitOfWork,
        ICustomerUpdateRepository customerUpdateRepository,
        ICustomerGetByIdRepository customerGetByIdRepository
    )
    {
        _unitOfWork = unitOfWork;
        _customerUpdateRepository = customerUpdateRepository;
        _customerGetByIdRepository = customerGetByIdRepository;
    }

    public async Task<bool> Handle(CustomerUpdateCommand req, CancellationToken token)
    {
        var customer = await _customerGetByIdRepository.CustomerGetById(req.Id, token);
        if (customer is null)
        {
            return false;
        }

        customer.Code = req.Code;
        customer.Name = req.Name;
        customer.Email = req.Email;
        customer.Age = req.Age;

        var result = await _customerUpdateRepository.UpdateCustomer(customer, token);

        await _unitOfWork.SaveChangesAsync(token);

        return result;
    }
}
