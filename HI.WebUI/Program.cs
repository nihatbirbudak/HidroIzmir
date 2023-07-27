using HI.BLL.Services.Abstract;
using HI.BLL.Services.HIServices;
using HI.Core.Data.UnitOfWork;
using HI.DAL;
using HI.WebUI.CumtomHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddSingleton<IUnitofWork, UnitofWork>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IContactService, ContactService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IUserService, UserService>();



//DbContaxt Setting
var optionsBuilder = new DbContextOptionsBuilder<HIDbContext>();
optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
optionsBuilder.EnableSensitiveDataLogging();

builder.Services.AddSingleton<DbContext>(new HIDbContext(optionsBuilder.Options));
using (var context = new HIDbContext(optionsBuilder.Options))
{
    context.Database.EnsureCreated();
    context.Database.Migrate();
}


// Login Settings
builder.Services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
builder.Services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

builder.Services.AddAuthentication("CookieAuthentication")
    .AddCookie("CookieAuthentication", config =>
    {
        config.Cookie.Name = "UserLoginCookie";
        config.LoginPath = "/Login";
        config.AccessDeniedPath = "/AccessDenied";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
