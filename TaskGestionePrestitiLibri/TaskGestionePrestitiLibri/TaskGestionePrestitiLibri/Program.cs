using TaskGestionePrestitiLibri.DAL;
using TaskGestionePrestitiLibri.Models;
using TaskGestionePrestitiLibri.Utilities;

namespace TaskGestionePrestitiLibri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Config.getInstance().GetConnectionString());
            Libro libro = new Libro()
            {
                Titolo="casa",
                AnnoPubblicazione=2000,
                isDisponibile=true,
                Isbn="ad"
            };
            LibroDal.GetInstance().Insert(libro);
            
        }
    }
}
