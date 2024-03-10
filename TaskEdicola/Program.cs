using TaskEdicola.Classes;

namespace TaskEdicola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edicola edicola = new Edicola();
            Pubblicazione giornaleUno = new Giornale("Corriere della sera", new DateTime(2024, 03, 03), "notizie", 1.40f, "01") { };
            Pubblicazione rivistaUno = new Rivista("Vogue", new DateTime(2024, 02, 02), "Moda", 6.0f, "02") { };
            Pubblicazione giornaleDue = new Giornale("Il Giornale", new DateTime(2023, 12, 05), "notizie", 1.70f, "03") { };
            edicola.aggiungiPubblicazione(giornaleUno);
            edicola.aggiungiPubblicazione(giornaleUno);
            edicola.aggiungiPubblicazione(giornaleUno);
            edicola.aggiungiPubblicazione(rivistaUno);
            Console.WriteLine( "-------------Stampa Inventario");
            edicola.stampaInventario();
            edicola.rimuoviPubblicazione(giornaleDue);
            Console.WriteLine( "---------------Rimozione");
            edicola.stampaInventario();
            Console.WriteLine("---------------Ricerca");
            edicola.ricercaInventario("02");
            edicola.aggiornaStock(giornaleUno, 28);
            edicola.stampaInventario();
            edicola.stampaDisponibilitaFiltrata();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Prova vendita");
            Pubblicazione giornaleDaVendere = new Giornale("Il Giornale", new DateTime(2023, 12, 05), "notizie", 1.70f, "03") { };
            edicola.aggiungiPubblicazione(giornaleDaVendere);
            edicola.vendiPubblicazione(giornaleDaVendere);
            edicola.stampaElencoVendite();
            
            edicola.stampaVenditePerData(DateTime.Now);
            
        }
    }
}
