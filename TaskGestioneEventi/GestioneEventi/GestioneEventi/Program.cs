using GestioneEventi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool navigazione=true;
           
            Console.WriteLine("Gestionale eventi");
            Console.WriteLine("Menu!");
            while (navigazione)
            {
                Console.WriteLine("1. Per inserire un evento 2.Per inserire un partecipante" +
                    " 3.Per Inserire Risorse 4.Visualizza Eventi 5.Visualizza tutti i partecipanti ad un evento" +
                    " 6.Visualizza tutte le risorse di un evento 7.Elimina Evento 0.Per uscire");
                try
                {
                    string? inserimento = Console.ReadLine();
                    switch(inserimento)
                    {
                        case "0":
                            Console.WriteLine("Olive Dolci!");
                            navigazione = false;
                            break;
                        case "1":
                            Console.WriteLine("Inserisci nome evento");
                            string nomeInput=Console.ReadLine();
                            Console.WriteLine("Inserisci descrizione");
                            string descrizioneInput = Console.ReadLine();
                            Console.WriteLine("Inserisci data evento (gg/mm/yyyy hh:mm:ss");
                            DateTime dataInput=Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Inserisci luogo evento");
                            string luogoInput = Console.ReadLine();
                            Console.WriteLine("Inserisci capacita max evento");
                            int capacitaMaxInput = Convert.ToInt32(Console.ReadLine());
                            Evento evento = new Evento()
                            {
                                NomeEvento = nomeInput,
                                Descrizione=descrizioneInput,
                                DataEvento=dataInput,
                                Luogo=luogoInput,
                                CapacitaMax=capacitaMaxInput
                            };
                            using(var ctx=new GestioneEventiContext())
                            {
                                ctx.Eventos.Add(evento);
                                ctx.SaveChanges();
                            }
                            break;
                        case "2":
                            Console.WriteLine("Inserisci nome partecipante");
                            string nomeParInput = Console.ReadLine();
                            Console.WriteLine("Inserisci cognome partecipante");
                            string cognomeParInput = Console.ReadLine();
                            Console.WriteLine("Inserisci codice fiscale");
                            string codFisInput = Console.ReadLine();
                            Console.WriteLine("Inserisci l id dell evento a cui partecipa");
                            int rifEventoInput=Convert.ToInt32(Console.ReadLine());



                            Partecipante partecipante = new Partecipante()
                            {
                                Nome = nomeParInput,
                                Cognome = cognomeParInput,
                                CodFis = codFisInput,
                                EventoRif=rifEventoInput
                            };
                            using (var ctx = new GestioneEventiContext())
                            {
                                ctx.Partecipantes.Add(partecipante);
                                ctx.SaveChanges();
                            }
                            break;
                        case "3":
                            Console.WriteLine("Inserisci nome risorsa");
                            string nomeRisInput = Console.ReadLine();
                            Console.WriteLine("Inserisci tipo risorsa");
                            string tipoRisInput = Console.ReadLine();
                            Console.WriteLine("Inserisci descrizione");
                            string desRisInput = Console.ReadLine();
                            Console.WriteLine("Inserisci la quantita della risorsa");
                            int quantRisInput = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Inserisci il costo unitario");
                            decimal costoRisInput = (decimal)Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Inserisci fornitore");
                            string forRisInput = Console.ReadLine();
                            Console.WriteLine("Inserisci l id dell evento nel quale verra utilizzata la risorsa");
                            int rifEventoRisInput = Convert.ToInt32(Console.ReadLine());



                            Risorsa risorsa = new Risorsa()
                            {
                                Nome = nomeRisInput,
                                Tipo = tipoRisInput,
                                Descrizione = desRisInput,
                                Quantita = quantRisInput,
                                CostoUnitario = costoRisInput,
                                Fornitore = forRisInput,
                                EventoRif = rifEventoRisInput
                                
                            };
                            using (var ctx = new GestioneEventiContext())
                            {
                                ctx.Risorsas.Add(risorsa);
                                ctx.SaveChanges();
                            }
                        break;
                        case "4":
                            ICollection<Evento> listaAllEventi= new List<Evento>();
                            using(var ctx = new GestioneEventiContext()) 
                            {
                                listaAllEventi=ctx.Eventos.ToList();
                                foreach(var e in listaAllEventi)
                                {
                                    Console.WriteLine($"Id:{e.EventoId} Nome:{e.NomeEvento}" +
                                        $" Data: {e.DataEvento} Luogo: {e.Luogo} Capacita:{e.CapacitaMax}");
                                }

                            }
                        break;
                        case "5":
                            Console.WriteLine("Inserisci l id dell evento desiderato");
                            int inputRicerca=Convert.ToInt32(Console.ReadLine());   
                            ICollection<Partecipante> listaPartecipantiByEvento= new List<Partecipante>();
                            using(var ctx=new GestioneEventiContext()) 
                            {
                                listaPartecipantiByEvento = ctx.Partecipantes.Where(p => p.EventoRif == inputRicerca).ToList();
                                foreach( var p in listaPartecipantiByEvento)
                                {
                                    Console.WriteLine($"Nome: {p.Nome} Cognome: {p.Cognome} Codice Fiscale: {p.CodFis}");
                                }
                            }
                        break;
                        case "6":
                            Console.WriteLine("Inserisci l id dell evento desiderato");
                            inputRicerca = Convert.ToInt32(Console.ReadLine());
                            ICollection<Risorsa> listaRisorseByEvento= new List<Risorsa>();
                            using (var ctx=new GestioneEventiContext())
                            {
                                listaRisorseByEvento=ctx.Risorsas.Where(r=> r.EventoRif==inputRicerca).ToList();
                                foreach (var r in listaRisorseByEvento)
                                {
                                    Console.WriteLine($"Nome: {r.Nome} Tipo: {r.Tipo} Descrizione: {r.Descrizione} Quantita: {r.Quantita}" +
                                        $" Costo Unitario: {r.CostoUnitario} Fornitore: {r.Fornitore} ");
                                }
                            }
                            break;
                        case "7":
                            //Console.WriteLine("Inserisci l id dell evento che vuoi eliminare");
                            // inputRicerca= Convert.ToInt32(Console.ReadLine());

                            
                            break;









                    }
                } catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    navigazione = false;
                }
               
            }
            
        }
    }
}
