using Domain.Abstractions;

namespace Application.Customer.Queries.GetById;

internal sealed class GetCustomerHandler : IRequest<GetCustomerByIdQuery, Guid>
{
    public async Task<Result<Guid>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return Result<Guid>.Success(Guid.NewGuid());
    }
}
