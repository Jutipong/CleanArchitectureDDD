using Domain.Abstractions;
using Domain.Interfaces;
using MediatR;

namespace Application.Customer.Queries.GetById;

internal sealed class GetCustomerHandler : IRequest<Guid>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<Guid>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetCustomerById(request.id);

        if (result is null)
        {
            return Result.Failure<Guid>(Error.NullValue);
        }

        return result;
    }
}
