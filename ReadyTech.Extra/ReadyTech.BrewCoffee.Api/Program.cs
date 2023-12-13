using Application;
using Common.ConfigOptions;
using Infrastructure;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInsfrastructureServices(builder.Configuration.GetConnectionString("RedisCache"));

// Validate App Settings
builder.Services.AddOptions<EndPointConfig>()
            .Bind(builder.Configuration.GetSection(EndPointConfig.EndPointSection))
            .ValidateDataAnnotations();

builder.Services.AddOptions<ConnectionConfig>()
            .Bind(builder.Configuration.GetSection(ConnectionConfig.CachingSection))
            .ValidateDataAnnotations();

builder.Services.AddOptions<CacheConfig>()
            .Bind(builder.Configuration.GetSection(CacheConfig.CachingSection))
            .ValidateDataAnnotations();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
