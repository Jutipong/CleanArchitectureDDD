namespace Application.Customer.Inquiry;

public record InquiryCustomerQuery(string Name) : IQuery<List<Entities.Customer>>;
