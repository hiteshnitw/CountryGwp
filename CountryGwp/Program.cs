using CountryGwp;
using CountryGwp.Models;
using CountryGwp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

if(builder.Environment.IsDevelopment())
{
    // Use an in-memory database for testing
    
}

builder.Services.AddControllers(
    configure =>
    {
        configure.Filters.Add(typeof(ExceptionFilter));
        configure.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddDbContext<CountryDbContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DbConnection"),
            sqlServerOptions =>
            {
                sqlServerOptions.CommandTimeout(120);
            })
        .EnableSensitiveDataLogging(builder.Environment.IsDevelopment()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (builder.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var svcs = scope.ServiceProvider;

        var context = svcs.GetRequiredService<CountryDbContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        //TODO: Load this data in a better way
        // Add services to the container.
        var data = CSVImporter.Import();
        context.LoadData(data);
    }
}

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseAuthorization();

app.MapControllers();

app.Run();
