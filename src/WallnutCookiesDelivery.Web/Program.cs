using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WallnutCookiesDelivery.DataAccess.Data;
using WallnutCookiesDelivery.Web.Service;
using WallnutCookiesDelivery.Web.ViewModels;
using WallnutCookiesDelivery.Application.Interfaces.IRepositories;
using WallnutCookiesDelivery.DataAccess.Repositories;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Application.Service;
using WallnutCookiesDelivery.Web.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnectionString")));
builder.Services.AddAutoMapper(typeof(Program));
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
