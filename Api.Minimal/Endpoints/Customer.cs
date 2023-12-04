using Carter;

namespace Api.Minimal.Endpoints;

public class Customer : CarterModule
{
    public Customer() : base("customer")
    {
        WithTags("Customer");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Create", () =>
        {
            return Results.Content("Crate");
        });

        app.MapGet("/GetById", () =>
        {
            return Results.Content("GetById");
        });
    }
}
