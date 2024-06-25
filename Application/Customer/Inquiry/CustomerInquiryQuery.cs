namespace Application.Customer.Inquiry;

public record InquiryCustomerQuery(string Name) : IRequest<List<Entities.Customer>>;
