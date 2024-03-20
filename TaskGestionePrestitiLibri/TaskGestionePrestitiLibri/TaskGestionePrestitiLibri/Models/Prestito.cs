using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGestionePrestitiLibri.Models
{
    internal class Prestito
    {
        
        public int PrestitoId { get; set; }
        public DateTime DataPrestito { get; set; }
        public DateTime DataRitorno { get; set; }
        public int UtenteRif {  get; set; }
        public int LibroRif {  get; set; }

        public Prestito() { }
        public Prestito(int prestitoId, DateTime dataPrestito, DateTime dataRitorno, int utenteRif, int libroRif)
        {
            PrestitoId = prestitoId;
            DataPrestito = dataPrestito;
            DataRitorno = dataRitorno;
            UtenteRif = utenteRif;
            LibroRif = libroRif;
        }
    }
}
