

namespace Application.Customer.Commands.Delete;
public record DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        _customerRepository.DelteCustomer(request.id, cancellationToken);

        return Task.FromResult(Result.Success());
    }
}
