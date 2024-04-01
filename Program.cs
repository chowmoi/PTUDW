
using Microsoft.EntityFrameworkCore;
using CanteenFireTech.ModelsNhap;
using CanteenFireTech.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("CanTeenFireTechContext");
builder.Services.AddDbContext<CanteenFireTechContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<ILoaiSanPhamRespository, LoaiSanPhamRespository>();

builder.Services.AddSession();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
