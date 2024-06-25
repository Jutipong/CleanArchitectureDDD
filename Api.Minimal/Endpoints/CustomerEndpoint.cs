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
            async (ISender sender, CreateCustomerCommand req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );

        app.MapPut(
            "/Update",
            async (ISender sender, UpdateCustomerCommand req, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(req, cancellationToken);
                return result;
            }
        );

        app.MapDelete(
            "/Delete{id}",
            async (ISender sender, Guid id, CancellationToken token) =>
            {
                var result = await sender.Send(new DeleteCustomerCommand(id), token);
                return result;
            }
        );

        app.MapGet(
            "/GetById/{id}",
            async (ISender sender, Guid id, CancellationToken token) =>
            {
                var result = await sender.Send(new GetCustomerByIdQuery(id), token);
                return result;
            }
        );

        app.MapPost(
            "/Inquiry",
            async (ISender sender, InquiryCustomerQuery req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );

        app.MapPost(
            "/Demo_EfCore_Dapper",
            async (ISender sender, DapperHandlerQuery req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );
    }
}
