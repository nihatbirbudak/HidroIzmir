using HI.BLL.Services.Abstract;
using HI.BLL.Services.HIServices;
using HI.Core.Data.UnitOfWork;
using HI.DAL;
using HI.WebUI.CumtomHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddSingleton<IUnitofWork, UnitofWork>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IContactService, ContactService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IRoleService, RoleService>();
builder.Services.AddSingleton<IimagePathService, ImagePathService>();
builder.Services.AddSingleton<IMainCategoryService, MainCategoryService>();
builder.Services.AddSingleton<IAboutService, AboutService>();
builder.Services.AddSingleton<IContactPageService, ContactPageService>();
builder.Services.AddSingleton<ISliderService, SliderService>();
builder.Services.AddSingleton<IDealersService, DealerService>();



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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "AccessDenied",
    pattern: "AccessDenied",
    defaults: new { controller = "Login", action = "AccessDenied" });

app.MapControllerRoute(
    name: "Anasayfa",
    pattern: "Anasayfa",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "Contact",
    pattern: "iletisim",
    defaults: new { controller = "Home", action = "Contact" });

app.MapControllerRoute(
    name: "ProductList",
    pattern: "urunler",
    defaults: new { controller = "Home", action = "ProductList" });

app.MapControllerRoute(
    name: "ProductListDetail",
    pattern: "urunler/{id:int}",
    defaults: new { controller = "Home", action = "ProductListDetail" });

app.MapControllerRoute(
    name: "About",
    pattern: "kurumsal/{name}",
    defaults: new { controller = "Home", action = "About" });

app.MapControllerRoute(
    name: "default2",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default3",
    pattern: "{controller=Login}/{action=UserLogin}");

app.MapControllerRoute(
    name: "Admin",
    pattern: "Admin",
    defaults: new { controller = "Admin", action = "Index" });

app.MapDefaultControllerRoute();

app.Run();
