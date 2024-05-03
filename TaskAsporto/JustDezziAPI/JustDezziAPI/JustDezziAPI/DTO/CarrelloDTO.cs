using JustDezziAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace JustDezziAPI.DTO
{
    public class CarrelloDTO
    {
        [Required]
        
        public int UtenteRif { get; set; } 

        // Lista dei piatti nel carrello
        public ICollection<CarrelloPiatto> Piatti { get; set; } = new List<CarrelloPiatto>();
    }
}
