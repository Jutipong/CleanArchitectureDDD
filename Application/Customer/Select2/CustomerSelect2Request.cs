namespace Application.Customer.Select2;

public class CustomerSelect2Request : IRequest<List<CustomerSelect2Response>>
{
    public string? TextSearch { get; init; }
    public List<Guid>? IdInit { get; init; }
    public int? PageSize { get; init; }
}
