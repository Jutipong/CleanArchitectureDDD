namespace Application.Abstractions.Messaging;

public interface IRequestResult : IRequest<Result>, ICommandBaseCustom { }

public interface IRequestResult<TResponse> : IRequest<Result<TResponse>>, ICommandBaseCustom { }

public interface ICommandBaseCustom { }
