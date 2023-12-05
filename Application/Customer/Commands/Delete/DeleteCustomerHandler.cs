

namespace Application.Customer.Commands.Delete;
public record DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand, Guid>
{
    public Task<Result<Guid>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success(request.id));
    }
}
