using GestioneImpiegati.Models;
using GestioneImpiegati.Repos;
using GestioneImpiegati.Services;
using Microsoft.EntityFrameworkCore;

namespace GestioneImpiegati
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GestioneImpiegatiContext>(
               options => options.UseSqlServer(
                   builder.Configuration.GetConnectionString("Locale")
                   )
               );
            builder.Services.AddScoped<ImpiegatoRepo>();
            builder.Services.AddScoped<ImpiegatiService>();

            builder.Services.AddScoped<RepartoRepo>();
            builder.Services.AddScoped<RepartoService>();
            //TODO:inserire gli altri scope
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Impiegati/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Impiegati}/{action=Lista}/{id?}");

            app.Run();
        }
    }
}
