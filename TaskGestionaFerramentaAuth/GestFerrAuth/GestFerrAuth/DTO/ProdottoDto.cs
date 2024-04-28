namespace GestFerrAuth.DTO
{
    public class ProdottoDto
    {
        public string Cod { get; set; } = null!;

        public string Nom { get; set; } = null!;

        public string Cat { get; set; } = null!;

        public string? Des { get; set; }

        public decimal Pre { get; set; }

        public int Qua { get; set; }
    }
}
