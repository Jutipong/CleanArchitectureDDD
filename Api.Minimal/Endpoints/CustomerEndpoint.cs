using Application.Customer.Autocomplete;
using Application.Customer.Create;
using Application.Customer.Dapper;
using Application.Customer.Delete;
using Application.Customer.GetById;
using Application.Customer.Inquiry;
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
            async (ISender sender, CustomerCreateRequest req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );

        app.MapPut(
            "/Update",
            async (ISender sender, CustomerUpdateRequest req, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(req, cancellationToken);
                return result;
            }
        );

        app.MapDelete(
            "/Delete{id}",
            async (ISender sender, Guid id, CancellationToken token) =>
            {
                var result = await sender.Send(new CustomerDeleteRequest(id), token);
                return result;
            }
        );

        app.MapGet(
            "/GetById/{id}",
            async (ISender sender, Guid id, CancellationToken token) =>
            {
                var result = await sender.Send(new CustomerGetByIdRequest(id), token);
                return result;
            }
        );

        app.MapPost(
            "/Inquiry",
            async (ISender sender, CustomerInquiryRequest req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );

        app.MapPost(
            "/Demo_EfCore_Dapper",
            async (ISender sender, CustomerDapperRequest req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );

        app.MapPost(
            "/AutocompleteServer",
            async (ISender sender, CustomerAutocompleteRequest req, CancellationToken token) =>
            {
                var result = await sender.Send(req, token);
                return result;
            }
        );
    }
}
