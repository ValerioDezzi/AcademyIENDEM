using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEdicola.Classes
{
    internal class Rivista: Pubblicazione
    {
        public bool isMensile = false;
        public Rivista() 
        {
          
           
        }
        public Rivista(string? titolo, DateTime dataPubblicazione, string? categoria, double prezzo, string codice)
        {
            Titolo = titolo;
            DataPubblicazione = dataPubblicazione;
            Categoria = categoria;
            Prezzo = prezzo;
            Codice = codice;
            
        }

        public override void stampaDettagli()
        {
            Console.WriteLine($"[RIVISTA] Titolo: {Titolo} Data: {DataPubblicazione.ToString("dd/MM/yyyy")} " +
                $"Categoria: {Categoria} Prezzo: {Prezzo}$ Codice: {Codice} Stock:{Contatore}");
        }
    }
}
