namespace Application.Abstractions.Messaging;


public interface IQuery : IRequest<Result>, IBaseQuery
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>, IBaseQuery
{
}

public interface IBaseQuery
{
}
