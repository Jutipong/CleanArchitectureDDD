using Application.Customer.Create;
using Application.Customer.Update;

namespace Api.Minimal.Endpoints;

public class TransectionEndpoint : CarterModule
{
    public TransectionEndpoint()
        : base("customer")
    {
        WithTags("Customer");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/Create",
            async (ISender sender, CustomerCreateRequest req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );

        app.MapPost(
            "/Update",
            async (ISender sender, CustomerUpdateRequest req, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(req, cancellationToken);
                return result;
            }
        );
    }
}
