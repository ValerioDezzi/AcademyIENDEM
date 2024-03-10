using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEdicola.Classes
{
    internal partial class Edicola
    {
        public string? NomeEdicola { get; set; }
        public List<Pubblicazione>Inventario { get; set; }=new List<Pubblicazione>();
        

        public void aggiungiPubblicazione(Pubblicazione inputPubblicazione)
        {
            if(Inventario.Contains(inputPubblicazione))
            {
                
                inputPubblicazione.Contatore++;
            }
            else
            {
                Inventario.Add(inputPubblicazione);
                inputPubblicazione.Contatore++;
            }

                

        }
        public void stampaInventario()
        {
            foreach(Pubblicazione pubblicazione in Inventario)
            {
                pubblicazione.stampaDettagli();

            }
        }
        public void rimuoviPubblicazione(Pubblicazione inputPubblicazione)
        {
            if (Inventario.Contains(inputPubblicazione))
            {
                Inventario.Remove(inputPubblicazione);
                inputPubblicazione.Contatore--;
                
            }
            else
            {
                Console.WriteLine("Elemento non presente nell inventario");
            }

        }
        public void ricercaInventario(string? codiceInput)
        {
            foreach(Pubblicazione p in Inventario)
            {
                if(p.Codice is not null &&  p.Codice.Equals(codiceInput))
                {
                    p.stampaDettagli();
                }
            }
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
