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
        private string? Nome { get; set; }
        private string? Cognome { get; set; }
        private string? Email { get; set; }

        #region Costruttori
        public Utente() { }
        public Utente(int utenteID, string? nome, string? cognome, string? email)
        {
            UtenteID = utenteID;
            Nome = nome;
            Cognome = cognome;
            Email = email;
        }
        #endregion 
    }
}
