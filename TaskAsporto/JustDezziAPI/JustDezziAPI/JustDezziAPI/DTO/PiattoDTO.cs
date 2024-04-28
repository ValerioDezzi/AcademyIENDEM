using JustDezziAPI.Models;

namespace JustDezziAPI.DTO
{
    public class PiattoDTO
    {

        public string Cod { get; set; } = null!;

        public string Nom { get; set; } = null!;

        public string Des { get; set; } = null!;

        public decimal Pre { get; set; }
        public int RistoranteRif { get; set; }


    }
}
