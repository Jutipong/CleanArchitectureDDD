namespace Application.Customer.Inquiry;

public record CustomerInquiryQuery(string Name) : IRequest<List<Entities.Customer>>;
