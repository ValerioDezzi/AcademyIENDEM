using JustDezziAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace JustDezziAPI.DTO
{
    public class PiattoDTO
    {
        [Required]
        public string Cod { get; set; } = null!;
        [Required]
        public string Nom { get; set; } = null!;
        [Required]
        public string Des { get; set; } = null!;
        [Required]
        public decimal Pre { get; set; }
        [Required]
        public int RistoranteRif { get; set; }


    }
}
