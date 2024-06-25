using Domain.Interfaces.Customer;

namespace Application.Customer.Delete;

internal sealed class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerDeleteRepository _repo;

    public CustomerDeleteHandler(IUnitOfWork unitOfWork, ICustomerDeleteRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<bool> Handle(CustomerDeleteCommand request, CancellationToken token)
    {
        _repo.DeleteCustomer(request.Id, token);

        await _unitOfWork.SaveChangesAsync(token);

        return true;
    }
}
