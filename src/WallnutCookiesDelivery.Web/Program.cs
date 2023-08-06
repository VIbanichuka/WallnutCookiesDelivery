using Microsoft.EntityFrameworkCore;
using WallnutCookiesDelivery.DataAccess.Data;
using WallnutCookiesDelivery.Web.Service;
using WallnutCookiesDelivery.Application.Interfaces.IRepositories;
using WallnutCookiesDelivery.DataAccess.Repositories;
using WallnutCookiesDelivery.Application.Interfaces.IServices;
using WallnutCookiesDelivery.Application.Service;
using WallnutCookiesDelivery.Web.Service.Interface;
using Microsoft.AspNetCore.Identity;
using WallnutCookiesDelivery.DataAccess.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnectionString")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;

    var userManager = scopedProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var identityDbContext = scopedProvider.GetRequiredService<ApplicationDbContext>();
    await IdentityDbContextSeed.SeedAsync(identityDbContext, userManager, roleManager);
}

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
