using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEdicola.Classes
{
    internal class Giornale : Pubblicazione
    {
        public bool HasInserto = false;
        

        public Giornale() 
        {
            
        }
        public Giornale(string? titolo, DateTime dataPubblicazione, string categoria, double prezzo, string codice)
        {
            Titolo = titolo;
            DataPubblicazione = dataPubblicazione;
            Categoria = categoria;
            Prezzo = prezzo;
            Codice = codice;
            
        }



        public override void stampaDettagli()
        {
            Console.WriteLine($"[GIORNALE] Titolo: {Titolo} Data: {DataPubblicazione.ToString("dd/MM/yyyy")} " +
                $"Categoria: {Categoria} Prezzo: {Prezzo}$ Codice: {Codice} Stock:{Contatore} ");
        }
       
    }
}
