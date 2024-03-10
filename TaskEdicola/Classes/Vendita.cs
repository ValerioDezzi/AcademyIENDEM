using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEdicola.Classes
{
    internal class Vendita
    {
        public DateTime DataVendita {  get; set; }
        public Pubblicazione? OggettoVenduto { get; private set; }
        public float? Prezzo { get; set; }

        public Vendita() { }
        public Vendita(DateTime dataVendita, Pubblicazione oggettoVenduto, float? prezzo)
        {
            DataVendita = dataVendita;
            OggettoVenduto = oggettoVenduto;
            Prezzo = prezzo;
        }
        public void stampaDettagli()
        {
            Console.WriteLine($"[VENDITA] Data : {DataVendita.ToString("dd/MM/yyyy")}" +
                $"Pubblicazione {OggettoVenduto?.Titolo} Prezzo: {Prezzo}" ) ;
        }

    }
}
