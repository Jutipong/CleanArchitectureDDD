using Domain.Abstractions;

namespace Application.Abstractions.Messaging;

public interface IValidate : MediatR.IRequest<Result>, IValidateBase
{
}

public interface IValidate<TResponse> : MediatR.IRequest<Result<TResponse>>, IValidateBase
{
}

public interface IValidateBase
{
}