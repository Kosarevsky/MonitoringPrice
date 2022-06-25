using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Interfaces;
using MonitoringPrice.WebApi;
using MonitoringPrice.WebApi.Entities.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Bind("Project", new Config());

builder.Services.AddScoped<IUnitOfWork, EntityUnitOfWork>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
