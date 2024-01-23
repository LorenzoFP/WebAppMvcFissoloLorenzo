using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAppMvcFissoloLorenzo.Data;
using WebAppMvcFissoloLorenzo.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAppMvcFissoloLorenzoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppMvcFissoloLorenzoContext") ?? throw new InvalidOperationException("Connection string 'WebAppMvcFissoloLorenzoContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    ImpiantoFissoloLorenzo.InizializzaFissoloLorenzo(services);
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
