
namespace Application.Customer.Commands.Update;

internal sealed class UpdateCustomerHandler : IRequestHandlerResult<UpdateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        _customerRepository.UpdateCustomer(request.Adapt<Entities.Customer>());

        return Task.FromResult(Result.Success());
    }
}