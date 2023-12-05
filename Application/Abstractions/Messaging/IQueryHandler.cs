namespace Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, Result>
    where TQuery : IRequest<Result>, IBaseQuery
{
}

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}