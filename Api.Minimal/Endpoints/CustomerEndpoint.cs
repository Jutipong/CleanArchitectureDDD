using Application.Customer.Create;
using Application.Customer.Delete;
using Application.Customer.GetById;
using Application.Customer.Inquiry;
using Application.Customer.TestMockData;
using Application.Customer.Update;

namespace Api.Minimal.Endpoints;

public class CustomerEndpoint : CarterModule
{
    public CustomerEndpoint()
        : base("customer")
    {
        WithTags("Customer");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/Create",
            async (ISender sender, CreateCustomerCommand req, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(req, cancellationToken);
                return result;
            }
        );

        app.MapPost(
            "/Update",
            async (ISender sender, UpdateCustomerCommand req, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(req, cancellationToken);
                return result;
            }
        );

        app.MapPost(
            "/Delete",
            async (ISender sender, DeleteCustomerCommand req, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(req, cancellationToken);
                return result;
            }
        );

        app.MapGet(
            "/GetById/{id}",
            async (ISender sender, Guid id, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(new GetCustomerByIdQuery(id), cancellationToken);
                return result;
            }
        );

        app.MapPost(
            "/Inquiry",
            async (ISender sender, InquiryCustomerQuery req, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(req, cancellationToken);
                return result;
            }
        );

        app.MapGet(
            "/Demo_EfCore_Dapper",
            async (ISender sender, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(new TestDapperHandlerQuery(""), cancellationToken);
                return result;
            }
        );
    }
}
