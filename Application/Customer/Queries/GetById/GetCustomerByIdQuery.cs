namespace Application.Customer.Queries.GetById;

public record GetCustomerByIdQuery(Guid id) : IQuery<Guid>;

public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(r => r.id).NotEmpty();
    }
}
