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
        public int AnnoPubblicazione { get; set; }
        public bool isDisponibile { get; set; }=false;
        public string? Isbn { get; set; }
        public List<Prestito>? ElencoPrestiti { get; set; } = new List<Prestito>();

        #region Costruttori
        public Libro() { }
        public Libro(string? titolo,int annoPubblicazione, bool isDisponibile ,string isbn)
        {
            
            Titolo = titolo;
            AnnoPubblicazione = annoPubblicazione;
            this.isDisponibile = isDisponibile;
            Isbn = isbn;
        }

        #endregion
    }
}
