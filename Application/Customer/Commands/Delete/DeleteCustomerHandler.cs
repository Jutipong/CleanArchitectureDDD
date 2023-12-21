

namespace Application.Customer.Commands.Delete;
public record DeleteCustomerHandler : IRequestHandlerResult<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        _customerRepository.DeleteCustomer(request.Id, cancellationToken);

        return Task.FromResult(Result.Success());
    }
}
