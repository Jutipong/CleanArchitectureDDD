namespace Application.Customer.Delete;

internal sealed class DeleteCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    : IQueryHandler<DeleteCustomerCommand>
{
    public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        customerRepository.DeleteCustomer(request.Id, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
