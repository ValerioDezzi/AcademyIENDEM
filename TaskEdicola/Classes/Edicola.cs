using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TaskEdicola.Classes
{
    internal partial class Edicola
    {
        public string? NomeEdicola { get; set; }
        public List<Pubblicazione> Inventario { get; set; } = new List<Pubblicazione>();


        public void aggiungiPubblicazione(Pubblicazione inputPubblicazione, int inputQuantità)
        {
            if (Inventario.Contains(inputPubblicazione))
            {

                inputPubblicazione.Contatore += inputQuantità;
            }
            else
            {
                Inventario.Add(inputPubblicazione);
                inputPubblicazione.Contatore += inputQuantità;
            }



        }
        public void stampaInventario()
        {
            foreach (Pubblicazione pubblicazione in Inventario)
            {
                pubblicazione.stampaDettagli();

            }
        }
        public void rimuoviPubblicazione(string codice, int quantita)
        {
            foreach (Pubblicazione p in Inventario)
            {
                if (p.Codice is not null && p.Codice.Equals(codice))
                {
                    p.Contatore -= quantita;
                    if(p.Contatore<=0)
                    {
                        Console.WriteLine("Elemento in negativo");
                      
                    }
                }
                else
                {
                    Console.WriteLine("Elemento non presente nell inventario");
                }
            }

        }
        public void stampaRicercaInventario(string? codiceInput)
        {
            foreach (Pubblicazione p in Inventario)
            {
                if (p.Codice is not null && p.Codice.Equals(codiceInput))
                {
                    p.stampaDettagli();
                }
 
                    Console.WriteLine("Pubblicazione non trovata");
                
            }
        }
        public bool IsInInventario(string codice)
        {
            if (codice is not null)
            {
                foreach (Pubblicazione p in Inventario)
                {
                    if (p.Codice.Equals(codice))
                        return true;
                }
            }
            return false;
        }
        public Pubblicazione GetPubblicazione(string codice)
        {
            foreach (Pubblicazione p in Inventario)
            {
                if (p.Codice == codice)
                {
                    return p;
                }
            }
            throw new ArgumentException($"Pubblicazione con codice {codice} non trovata nell'inventario.");
        }



    public void aggiornaStock(Pubblicazione pubblicazione,int inputAggiornamento)
        {
            if(Inventario.Contains(pubblicazione))
            {
                pubblicazione.Contatore=inputAggiornamento;
            }
            else 
            { 
                Console.WriteLine("Errore di aggiornamento");
            }

        }

        public void stampaDisponibilitaFiltrata()
        {
            Console.WriteLine($"Disponibiltà Inventario Filtrata:");
            foreach (Pubblicazione p in Inventario)
            {
                if(p.Contatore>=0)
                {
                    Console.WriteLine($"{p.Codice} {p.Titolo}: {p.Contatore}");
                }
            }
        }
        
        
    }
}
