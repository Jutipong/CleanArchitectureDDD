
namespace Application.Customer.Queries.Search;

internal sealed class SearchCustomerHandler : IQueryHandler<SearchCustomerQuery, CustomerEntities>
{
    public Task<Result<CustomerEntities>> Handle(SearchCustomerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
