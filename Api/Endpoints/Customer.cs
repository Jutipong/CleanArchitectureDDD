using Carter;

namespace Api.Endpoints;

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
            return Results.Content("customer create");
        });

        app.MapGet("/GetById", () =>
        {
            return Results.Content("customer getById");
        });
    }
}
