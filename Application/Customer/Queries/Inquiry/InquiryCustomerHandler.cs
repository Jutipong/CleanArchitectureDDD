

namespace Application.Customer.Queries.Inquiry;
internal class InquiryCustomerHandler : IQueryHandler<InquiryCustomerQuery>
{
    public Task<Result> Handle(InquiryCustomerQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success());
    }
}
