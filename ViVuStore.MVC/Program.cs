using Microsoft.EntityFrameworkCore;
using ViVuStore.MVC.Data;
using ViVuStore.MVC.Repositories;
using ViVuStore.MVC.Services;
using ViVuStore.MVC.Services.BaseServices;
using ViVuStore.MVC.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DBContext
builder.Services.AddDbContext<ViVuStoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ViVuStoreDbConnection"));
});

// Register GenericRepository - DI
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Register UnitOfWork - DI
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register Services - DI
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


await app.RunAsync();
