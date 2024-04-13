namespace Application.Customer.Create;

internal sealed class CreateCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    : ICommandHandler<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerId = await customerRepository.CreateCustomer(request.Adapt<Entities.Customer>(), cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var result = Result.Success(customerId);
        return result;
    }
}
