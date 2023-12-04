﻿using Application.Customer.Commands.Create;
using Application.Customer.Queries.GetById;
using Carter;
using MediatR;

namespace Api.Minimal.Endpoints;

public class Customer : CarterModule
{
    public Customer() : base("customer")
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

        app.MapGet("/GetById/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetCustomerByIdQuery(id));
            return result;
        });
    }
}
