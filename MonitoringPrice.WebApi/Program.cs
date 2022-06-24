using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Interfaces;
using MonitoringPrice.WebApi;
using MonitoringPrice.WebApi.Entities.Context;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Bind("Project", new Config());

builder.Services.AddScoped<IUnitOfWork, EntityUnitOfWork>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

////настраиваем identity систему
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
//{
//    opts.User.RequireUniqueEmail = true;
//    opts.Password.RequiredLength = 6;
//    opts.Password.RequireNonAlphanumeric = false;
//    opts.Password.RequireLowercase = false;
//    opts.Password.RequireUppercase = false;
//    opts.Password.RequireDigit = false;
//}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();

//partial class Program
//{
//    public IConfiguration Configuration { get; }
//    public Program(IConfiguration configuration) => Configuration = configuration;
//}

