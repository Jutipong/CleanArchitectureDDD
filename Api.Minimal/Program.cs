using Api.Minimal.Extensions;
using Api.Minimal.Middleware;
using Application;
using Domain.Abstractions;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>()!;
builder.Services.AddSingleton(appConfig);

builder.Services.AddSwagger();
builder.Services.AddCorsPolicy(builder.Configuration);
builder.Services.AddCarter();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddJsonOptions();

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerEndpoints();
}

app.UseCorsPolicy();
app.UseSerilogRequestLogging();
app.UseMiddleware<RequestContextLogging>();
app.UseExceptionHandler();
app.MapCarter();
app.UseHttpsRedirection();
app.Run();
