using Domain.Abstractions;
using Domain.Dtos;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Customer.Commands.Create;

internal sealed class CreateCustomerHandler : IRequest<Result<CustomerEntities>>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result<CustomerEntities>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var obj = request.Adapt<CustomerDto>();
        var customer = await _customerRepository.CreateCustomer(obj);
        if (customer != null)
        {
            return Result.Failure<CustomerEntities>(new Error("User.Found", "The user with the specified identifier was not found"));
        }

        return customer;
    }

    //public async Task<Result<CustomerEntities>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    //{
    //    var obj = request.Adapt<CustomerEntities>();
    //    var customer = await _customerRepository.CreateCustomer(obj);
    //    if (customer != null)
    //    {
    //        return Result.Failure<CustomerEntities>(new Error("User.Found", "The user with the specified identifier was not found"));
    //    }

    //    return customer;
    //}
}
