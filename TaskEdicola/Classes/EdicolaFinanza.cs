using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEdicola.Classes
{
    internal partial class Edicola
    {
        public List<Vendita> elencoVendite=new List<Vendita>();
        

        public void vendiPubblicazione(Pubblicazione p)
        {
            if(p is not null && Inventario.Contains(p))
            {
                Vendita vendita = new Vendita(p.DataPubblicazione, p, p.Prezzo);
                elencoVendite.Add(vendita);
                rimuoviPubblicazione(p);
                Console.WriteLine($"{p.Titolo} e' stato venduto per {p.Prezzo}");
            }
            else
            {
                Console.WriteLine("Elemento non vendibile(non presente in inventario)");
                
            }
        }
        public void stampaElencoVendite()
        {
            foreach(Vendita vendita in elencoVendite)
            {
                vendita.stampaDettagli();
            }
        }
        public void stampaVenditePerData(DateTime dataInput)
        {
            foreach(Vendita vendita in elencoVendite)
            {
                if(vendita.DataVendita==dataInput)
                {
                    vendita.stampaDettagli();
                }
                
            }
        }
        
    }
}
