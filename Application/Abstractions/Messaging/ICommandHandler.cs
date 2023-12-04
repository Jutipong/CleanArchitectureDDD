using Domain.Abstractions;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface IRequest<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : IValidate
{
}

public interface IRequest<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : IValidate<TResponse>
{
}

