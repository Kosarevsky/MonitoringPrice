using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

//Configure the HTTP request pipeline.
//var baseAddress = "http://localhost:5201/api/";

//builder.Services.AddHttpClient<IManufacturerService, ManufacturerService>(client =>
//{
//    client.BaseAddress = new Uri(baseAddress);
//});

app.Run();

