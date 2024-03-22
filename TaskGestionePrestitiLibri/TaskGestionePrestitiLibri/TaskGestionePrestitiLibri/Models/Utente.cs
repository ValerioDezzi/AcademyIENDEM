using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGestionePrestitiLibri.Models
{
    internal class Utente
    {
        
        public  int UtenteID { get; set; }
        public  string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Email { get; set; }
        public string? Codice { get; set; }
        public List<Prestito>? ElencoPrestiti {  get; set; } = new List<Prestito>();


        #region Costruttori
        public Utente() { }
        public Utente(int utenteID, string? nome, string? cognome, string? email,string? codice)
        {
            UtenteID = utenteID;
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Codice = codice;
        }
        #endregion 
    }
}
