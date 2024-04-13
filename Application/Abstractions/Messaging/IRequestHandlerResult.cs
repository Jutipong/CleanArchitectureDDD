namespace Application.Abstractions.Messaging;

public interface IRequestHandlerResult<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : IRequestResult { }

public interface IRequestHandlerResult<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : IRequestResult<TResponse> { }
