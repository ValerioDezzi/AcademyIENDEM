using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEdicola.Classes
{
    internal abstract class Pubblicazione
    {
        public string? Titolo { get; set; }
        public DateTime DataPubblicazione { get; set; } = DateTime.Now;
        public string? Categoria { get; set; }
        public float Prezzo { get; set; } = 0;
        public string? Codice { get; set; }

        public  int Contatore { get; set; } = 0;
   

        public Pubblicazione() 
        {
            
        }
        public abstract void stampaDettagli();
    }
}
