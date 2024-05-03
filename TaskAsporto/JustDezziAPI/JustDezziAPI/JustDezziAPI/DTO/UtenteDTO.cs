using System.ComponentModel.DataAnnotations;

namespace JustDezziAPI.DTO
{
    public class UtenteDTO
    {

        public string Nom { get; set; }= null!;
        [Required]
        public string Pas { get; set; } = null!;
        [Required]
        public string Ind { get; set; } = null!;
        [Required]
        public string Ema { get; set; } = null!;

    }
}
