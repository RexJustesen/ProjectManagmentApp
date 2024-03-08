using Microsoft.EntityFrameworkCore;
using PmAPI.Models;
using PmAPI.Extensions;
using PmAPI.Data;
using PmAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();
app.UseRouting();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:4200", "https://localhost:8001")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedTickets(context);
}
catch(Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An Error occured during migration");
}

app.UseHttpsRedirection();

app.MapHub<ProjectsHub>("project-hub");
app.MapHub<TicketsHub>("ticket-hub");

app.Run();
