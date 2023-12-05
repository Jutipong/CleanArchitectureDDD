
namespace Application.Customer.Queries.Search;

internal sealed class SearchCustomerHandler : IRequestHandler<SearchCustomerQuery, CustomerEntities>
{
    public Task<CustomerEntities> Handle(SearchCustomerQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CustomerEntities());
    }
}
