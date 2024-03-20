using TaskGestionePrestitiLibri.DAL;
using TaskGestionePrestitiLibri.Models;

namespace TaskGestionePrestitiLibri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro("titolo", new DateTime(03/07/2020), true);
            LibroDal.GetInstance().Insert(libro);
        }
    }
}
