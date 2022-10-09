using MonitoringPrice.Web.Service;
using MonitoringPrice.Services.Interfaces;
using MonitoringPrice.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Bind("Project", new Config());

builder.Services.AddTransient<IManufacturerService, ManufacturerService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();

var uri = Config.WebApiPath;

builder.Services.AddHttpClient("Price",client =>
{
    client.BaseAddress = new Uri(uri); 
});


//настраиваем authentication cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "myCompanyAuth";
        options.Cookie.HttpOnly = true;
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        options.SlidingExpiration = true;
    });


//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.Name = "myCompanyAuth";
//    options.Cookie.HttpOnly = true;
//    options.LoginPath = "/account/login";
//    options.AccessDeniedPath = "/account/accessdenied";
//    options.SlidingExpiration = true;
//});

//настраиваем политику авторизации для Admin area
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

//добавляем сервисы для контроллеров и представлений (MVC)
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

var app = builder.Build();
if (app.Environment.IsDevelopment()) 
{ 
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();