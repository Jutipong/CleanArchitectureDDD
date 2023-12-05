namespace Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}

public interface IQuery : IRequest<Result>, IBaseQuery
{
}

public interface IBaseQuery
{
}
