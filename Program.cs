//using SchoolManagement.Infrastructure.Data;
//using SchoolManagement.Infrastructure.Repositories;
//using SchoolManagement.Application.Interfaces;
using SchoolManagement.Application.Services;
using Microsoft.EntityFrameworkCore;
using SchoolManagementMVC.SchoolManagement.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de datos (DbContext)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
