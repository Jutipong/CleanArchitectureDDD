using Domain.Abstractions;
using MediatR;

namespace Application.Abstractions.Messaging;

public interface IRequest<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface IRequest<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}

