

using GestFerrAuth.Models;
using GestFerrAuth.Repos;
using GestFerrAuth.Services;
using Microsoft.EntityFrameworkCore;

namespace GestFerrAuth
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

            builder.Services.AddDbContext<FerramentaContext>(options => options.UseSqlServer(
           builder.Configuration.GetConnectionString("DefaultConnection")
           ));
            builder.Services.AddScoped<ProdottoRepo>();
            builder.Services.AddScoped<ProdottoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
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
