using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskGestionePrestitiLibri.Models
{
    internal class Libro
    {
        
        public int LibroId { get; set; }
        public string? Titolo { get; set; }
        public DateTime AnnoPubblicazione { get; set; }
        public bool isDisponibile { get; set; }=false;
        #region Costruttori
        public Libro() { }
        public Libro(string? titolo,DateTime annoPubblicazione, bool isDisponibile)
        {
            
            Titolo = titolo;
            AnnoPubblicazione = annoPubblicazione;
            this.isDisponibile = isDisponibile;
        }

        #endregion
    }
}
