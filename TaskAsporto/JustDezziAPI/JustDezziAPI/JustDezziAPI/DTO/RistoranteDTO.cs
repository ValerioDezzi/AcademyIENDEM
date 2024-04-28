namespace JustDezziAPI.DTO
{
    public class RistoranteDTO
    {
        public string Cod { get; set; } = null!;

        public string Nom { get; set; } = null!;

        public string Tip { get; set; } = null!;

        public TimeOnly Ape { get; set; }

        public TimeOnly Chi { get; set; }

        public string Ind { get; set; } = null!;
    }
}
