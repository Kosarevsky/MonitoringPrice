using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyCompany.Service;
using MonitoringPrice.Web.Service;
using MonitoringPrice.WebApi.Interfaces;
using MonitoringPrice.WebApi.Entities.Context;
using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Bind("Project", new Config());

builder.Services.AddScoped<IUnitOfWork, EntityUnitOfWork>();


builder.Services.AddTransient<IManufacturerService, ManufacturerService>();

var uri = "http://localhost:5201/api/";
builder.Services.AddHttpClient<IManufacturerService, ManufacturerService>(client =>
{
    client.BaseAddress = new Uri(uri);
});


//builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>(); 
//builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
//builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
//builder.Services.AddTransient<ICharacteristicRepository, CharacteristicRepository>();
//builder.Services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
//builder.Services.AddTransient<IPriceRepository, PriceRepository>();
//builder.Services.AddTransient<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IRamRepository, RamRepository>();
//builder.Services.AddTransient<IUrlRepository, UrlRepository>();
//builder.Services.AddTransient<DbManager>();

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

//настраиваем identity систему
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//настраиваем authentication cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "myCompanyAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

//настраиваем политику авторизации для Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

//builder.Services.AddControllersWithViews();

//добавляем сервисы для контроллеров и представлений (MVC)
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

var app = builder.Build();

app.UseRouting();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapControllerRoute("default", "{controller=Payment}/{action=Index}/{id?}");
});

app.Run();

partial class Program
{
    public IConfiguration Configuration { get; }
    public Program(IConfiguration configuration) => Configuration = configuration;
}

