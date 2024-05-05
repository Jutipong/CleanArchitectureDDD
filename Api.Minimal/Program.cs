using Api.Minimal.Extensions;
using Api.Minimal.Middlewares;
using Application;
using Domain.Abstractions;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
var appConfig = config.GetSection(nameof(AppSettings)).Get<AppSettings>()!;
builder.Services.AddSingleton(appConfig);

var assembly = typeof(Program).Assembly;
builder.Services.AddSwagger();
builder.Services.AddCors();
builder.Services.AddCarter();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Host.UseSerilog(
    (context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration).Enrich.FromLogContext().WriteTo.Console();
    }
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerEndpoints();
}

app.UseSerilogRequestLogging();
app.UseMiddleware<RequestContextLogging>();
app.UseExceptionHandler();
app.MapCarter();
app.UseHttpsRedirection();
app.Run();
