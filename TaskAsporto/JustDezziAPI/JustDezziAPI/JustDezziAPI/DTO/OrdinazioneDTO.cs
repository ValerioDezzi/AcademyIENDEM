using System.ComponentModel.DataAnnotations;

namespace JustDezziAPI.DTO
{
    public class OrdinazioneDTO
    {
        [Required(ErrorMessage = "Il campo codice è obbligatorio.")]
        public string Codice { get; set; } = null!;

        public DateTime? DataOra { get; set; }

        public string? Istruzioni { get; set; }
        [Required(ErrorMessage = "Lo stato è obbligatorio.")]
        public string Stato { get; set; } = null!;
        [Required(ErrorMessage = "Il riferimento all'utente è obbligatorio.")]
        public int UtenteRif { get; set; }
        [Required(ErrorMessage = "Il riferimento al ristorante è obbligatorio.")]
        public int RistoranteRif { get; set; }
        [Required(ErrorMessage = "Il riferimento al carrello è obbligatorio.")]
        public int CarrelloRif { get; set; }

    }
}
