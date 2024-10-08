using Api.Controller.Extensions;
using Api.Controller.Middleware;
using Application;
using Domain.Abstractions;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>()!;
builder.Services.AddSingleton(appConfig);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSwagger();
builder.Services.AddCorsPolicy(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddJsonOptions();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerEndpoints();
}

app.UseCorsPolicy();
app.UseHttpsRedirection();
app.UseMiddleware<RequestContextLogging>();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
