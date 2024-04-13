namespace Application.Customer.Update;

internal sealed class UpdateCustomerHandler : IRequestHandlerResult<UpdateCustomerCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerById(request.Id, cancellationToken);

        if (customer is null)
        {
            return Result.Failure(Error.DataNotFound);
        }

        customer.Code = request.Code;
        customer.Name = request.Name;
        customer.Email = request.Email;
        customer.Age = request.Age;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
