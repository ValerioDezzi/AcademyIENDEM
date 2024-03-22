using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGestionePrestitiLibri.Utilities
{
    internal class Config
    {
        private static Config? instance;
        private string? connectionString;

        public static Config getInstance()
        {
            if (instance == null)
            {
                instance = new Config();
            }
            return instance;
        }
        private Config() { }
        public string? GetConnectionString()
        {
            if (connectionString==null)
            {
             ConfigurationBuilder builder = new ConfigurationBuilder();
             builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appSettings.json", optional: false, reloadOnChange: false);


                IConfiguration configuration = builder.Build();

                connectionString = configuration.GetConnectionString("ServerLocale");

            }
            return connectionString;
        }
    }
}
