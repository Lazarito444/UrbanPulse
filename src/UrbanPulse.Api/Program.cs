using Scalar.AspNetCore;
using UrbanPulse.Api.Extensions;
using UrbanPulse.Infrastructure.Extensions;
using UrbanPulse.ServiceDefaults;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

string dbConnectionString = builder.Configuration.GetConnectionString("urbanpulse-db")!;

builder.Services.SetupInfrastructure(dbConnectionString);
builder.Services.SetupApi();

WebApplication app = builder.Build();

app.ApplyMigrations();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.Run();
