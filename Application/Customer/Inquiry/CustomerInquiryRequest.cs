namespace Application.Customer.Inquiry;

public record CustomerInquiryRequest(string? Name) : IRequest<List<Entities.Customer>>;
