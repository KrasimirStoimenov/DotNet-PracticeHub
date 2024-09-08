using CarRentalSystem.Application;
using CarRentalSystem.Domain;
using CarRentalSystem.Infrastructure;
using CarRentalSystem.Startup;
using CarRentalSystem.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddDomain()
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddWebComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints
        => endpoints.MapControllers())
    .Initialize();

app.Run();
