namespace Application.Customer.Select2;

public record CustomerSelect2Request(string? Name, int? PageSize) : IRequest<List<CustomerSelect2Response>>;
