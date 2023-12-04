using Api.Extensions;
using Api.Middleware;
using Application;
using Carter;
using Domain.Abstractions;
using Infrastructure;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

var config = builder.Configuration;
var _config = config.GetSection(nameof(AppSettings)).Get<AppSettings>()!;
builder.Services.AddSingleton(_config);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var assembly = typeof(Program).Assembly;
builder.Services.AddSwagger();
builder.Services.AddCors();
builder.Services.AddCarter();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerEndpoints();
}

app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapCarter();
app.UseHttpsRedirection();
app.Run();