using Application.Transection.Create;
using Application.Transection.Update;

namespace Api.Minimal.Endpoints;

public class TransectionEndpoint : CarterModule
{
    public TransectionEndpoint()
        : base("transection")
    {
        WithTags("Transection");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/Create",
            async (ISender sender, CancellationToken token) =>
            {
                var result = await sender.Send(new TransectionCreateRequest(), token);
                return result;
            }
        );

        app.MapGet(
            "/Update",
            async (ISender sender, CancellationToken cancellationToken) =>
            {
                await sender.Send(new TransectionUpdateRequest(), cancellationToken);
            }
        );
    }
}
