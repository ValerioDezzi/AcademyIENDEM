
using JustDezziAPI.Models;
using JustDezziAPI.Repo;
using JustDezziAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace JustDezziAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //inizo imp personallizate
            builder.Services.AddDbContext<JustDezziContext>(options => options.UseSqlServer(
           builder.Configuration.GetConnectionString("DefaultConnection")
           ));
            builder.Services.AddScoped<UtenteRepo>();
            builder.Services.AddScoped<UtenteService>();

            builder.Services.AddScoped<RistoranteRepo>();
            builder.Services.AddScoped<RistoranteService>();

            builder.Services.AddScoped<PiattoRepo>();
            builder.Services.AddScoped<PiattoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //cors importantissime
            app.UseCors(builder =>
                   builder
                   .WithOrigins("*")
                   .AllowAnyMethod()
                   .AllowAnyHeader());


            app.MapControllers();

            app.Run();
        }
    }
}
