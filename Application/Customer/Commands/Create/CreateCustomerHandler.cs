using Domain.Abstractions;

namespace Application.Customer.Commands.Create;

internal sealed class CreateCustomerHandler : IRequest<CreateCustomerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        return Result<Guid>.Success(Guid.NewGuid());
    }
}
