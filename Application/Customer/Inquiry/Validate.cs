namespace Application.Customer.Inquiry;

public class Validate : AbstractValidator<CustomerInquiryQuery>
{
    public Validate()
    {
        RuleFor(r => r.Name).NotEmpty();
    }
}
