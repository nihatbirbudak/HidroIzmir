using HI.BLL.Services.Abstract;
using HI.BLL.Services.HIServices;
using HI.Core.Data.UnitOfWork;
using HI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
var optionBuilder = new DbContextOptionsBuilder<HIDbContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("HIDbContext"));
optionBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
optionBuilder.EnableSensitiveDataLogging();

builder.




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
