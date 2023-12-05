namespace Application.Customer.Commands.Update;

// 1
internal sealed class UpdateCustomerHandler : ICommandHandler<UpdateCustomerCommand>
{
    public Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}