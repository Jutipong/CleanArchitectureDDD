namespace Application.Customer.Inquiry;

public class Validate : AbstractValidator<InquiryCustomerQuery>
{
    public Validate()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}
