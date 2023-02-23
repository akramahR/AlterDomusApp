using AlterDomusApp.Core;
using AlterDomusApp.Core.Interfaces.Services;
using AlterDomusApp.Core.Services;
using AlterDomusApp.Core.Shared;
using AlterDomusApp.Github.Extensions;
using AlterDomusAssignment.Middlewares;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//pre configure the client created by factory for github with base uri and headers
builder.Services.AddHttpClient(HttpClientNames.Github, httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["GithubBaseUrl"]);

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/vnd.github+json");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "AlterDomus");
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCoreServices();
builder.Services.AddGithubClientServices();
//Configure application insights
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();

//required for integration testing
public partial class Program { }