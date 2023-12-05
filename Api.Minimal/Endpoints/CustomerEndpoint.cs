﻿using Application.Customer.Commands.Create;
using Application.Customer.Commands.Delete;
using Application.Customer.Commands.Update;
using Application.Customer.Queries.GetById;

namespace Api.Minimal.Endpoints;

public class CustomerEndpoint : CarterModule
{
    public CustomerEndpoint() : base("customer")
    {
        WithTags("Customer");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Create", async (ISender sender, CreateCustomerCommand req) =>
        {
            var result = await sender.Send(req);
            return result;
        });

        app.MapPost("/Create2", async (ISender sender, CreateCustomerCommand2 req) =>
        {
            var result = await sender.Send(req);
            return result;
        });

        app.MapPost("/Update", async (ISender sender, UpdateCustomerCommand req) =>
        {
            var result = await sender.Send(req);
            return result;
        });

        app.MapPost("/Delete", async (ISender sender, DeleteCustomerCommand req) =>
        {
            var result = await sender.Send(req);
            return result;
        });

        app.MapGet("/GetById/{id}", async (ISender sender, Guid id) =>
        {
            var result = await sender.Send(new GetCustomerByIdQuery(id));
            return result;
        });
    }
}
