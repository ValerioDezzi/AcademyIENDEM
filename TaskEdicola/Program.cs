using System.Linq.Expressions;
using TaskEdicola.Classes;

namespace TaskEdicola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Edicola edicola = new Edicola();

            bool interazioneAbilitata=true;
            Console.WriteLine("Benvenuto,segui le istruzione per navigare");
            while ( interazioneAbilitata )
            {
                Console.WriteLine("Cosa vuoi fare?");
                //aggiungiPubblicazione stampaInventariorimuoviPubblicazionericercaInventario
                Console.WriteLine("1:Aggiungi Pubblicazione 2: Stampa Inventario 3:Rimuovi Pubblicazione 4:Ricerca Inventario" +
                    "\n 5: Stampa Inventario Filtrato 0:Esci: ");
                try {
                    string? input = Console.ReadLine();

                    switch (input)
                    {


                        case "0":
                        {
                                Console.WriteLine("Arrivederci!");
                                interazioneAbilitata = false;
                                break;

                        }          
                        case "1":
                            {
                                Console.WriteLine("1.Giornale 2.Rivista");
                                string? scelta = Console.ReadLine();
                                if (scelta is not null && scelta.Equals("1"))
                                {
                                    Pubblicazione giornale = new Giornale();
                                    DateTime dataInput = DateTime.Now;

                                    Console.WriteLine("Inserisci Titolo");
                                    giornale.Titolo = Console.ReadLine();

                                    Console.WriteLine("Inserisci Data di pubblicazione (dd/mm/yyyy:");
                                    dataInput = DateTime.Parse(Console.ReadLine());

                                    giornale.DataPubblicazione = dataInput;

                                    Console.WriteLine("Inserisci Categoria:");
                                    giornale.Categoria = Console.ReadLine();

                                    Console.WriteLine("Inserisci Prezzo:");
                                    giornale.Prezzo = double.Parse(Console.ReadLine());

                                    Console.WriteLine("Inserisci Codice:");
                                    giornale.Codice = Console.ReadLine();

                                    Console.WriteLine("Quante unità inserire nell'inventario?");
                                    int inputQuantita = int.Parse(Console.ReadLine());
                                    edicola.aggiungiPubblicazione(giornale, inputQuantita);
                                    Console.WriteLine("Inserimento completato con successo!");
                                    edicola.stampaInventario();

                                    break;
                                }
                                else if (scelta is not null && scelta.Equals("2"))
                                {
                                    Pubblicazione rivista = new Rivista();
                                    DateTime dataInput = DateTime.Now;

                                    Console.WriteLine("Inserisci Titolo");
                                    rivista.Titolo = Console.ReadLine();

                                    Console.WriteLine("Inserisci Data di pubblicazione (dd/mm/yyyy:");
                                    dataInput = DateTime.Parse(Console.ReadLine());

                                    rivista.DataPubblicazione = dataInput;

                                    Console.WriteLine("Inserisci Categoria:");
                                    rivista.Categoria = Console.ReadLine();

                                    Console.WriteLine("Inserisci Prezzo:");
                                    rivista.Prezzo = double.Parse(Console.ReadLine());

                                    Console.WriteLine("Inserisci Codice:");
                                    rivista.Codice = Console.ReadLine();

                                    Console.WriteLine("Quante unità inserire nell'inventario?");
                                    int inputQuantita = int.Parse(Console.ReadLine());
                                    edicola.aggiungiPubblicazione(rivista, inputQuantita);
                                    Console.WriteLine("Inserimento completato con successo!");
                                    edicola.stampaInventario();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Inserimento non valido!");
                                    break;
                                }
                            }
                        case "2":
                            edicola.stampaInventario();
                            break;
                        case "3":
                            Console.WriteLine("Inserisci il codice della pubblicazione che vuoi eliminare: ");
                            string? inputCodice=Console.ReadLine();
                            Console.WriteLine("Quanti ne vuoi eliminare? :");
                            int inputQuantita1=int.Parse(Console.ReadLine());
                            edicola.rimuoviPubblicazione(inputCodice, inputQuantita1);
                            Console.WriteLine("Elemento rimosso con successo!");
                            break;
                        case "4":
                            {
                                Console.WriteLine("Inserisci il codice della pubblicazione che stai cercando");
                                string inputCodice1= Console.ReadLine();
                                edicola.GetPubblicazione(inputCodice1).stampaDettagli();
                                break;
                            }
                        case "5": 
                            { 
                                edicola.stampaDisponibilitaFiltrata();
                                break;
                            }
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine($"Errore {ex.Message} ");
                }
            }
        }
    }
}
