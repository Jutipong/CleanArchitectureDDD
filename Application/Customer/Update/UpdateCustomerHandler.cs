namespace Application.Customer.Update;

internal sealed class UpdateCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    : ICommandHandler<UpdateCustomerCommand>
{
    public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetCustomerById(request.Id, cancellationToken);

        if (customer is null)
        {
            return Result.Failure(Error.DataNotFound);
        }

        customer.Code = request.Code;
        customer.Name = request.Name;
        customer.Email = request.Email;
        customer.Age = request.Age;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
