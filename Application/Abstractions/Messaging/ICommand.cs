using Domain.Abstractions;

namespace Application.Abstractions.Messaging;

public interface ICommand : MediatR.IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TResponse> : MediatR.IRequest<Result<TResponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}