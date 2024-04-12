
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Repos;
using GestionaleMarioKart.Services;
using Microsoft.EntityFrameworkCore;

namespace GestionaleMarioKart
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
            
            builder.Services.AddDbContext<MariokartContext>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            builder.Services.AddScoped<GiocatoreRepo>();
            builder.Services.AddScoped<GiocatoreService>();

            builder.Services.AddScoped<IRepo<Squadra>, SquadraRepo>();
            builder.Services.AddScoped<SquadraService>();

            builder.Services.AddScoped<IRepo<Personaggio>, PersonaggioRepo>();
            builder.Services.AddScoped<PersonaggioService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
