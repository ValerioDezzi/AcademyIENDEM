namespace GestioneEsa.Models
{
    public class ContenitoreCeleste
    {
        public int ContenitoreId { get; set; }

        public string Codice { get; set; } = Guid.NewGuid().ToString().ToUpper();

        public string Nome { get; set; } = null!;

        public string? Tipo { get; set; }
        public IEnumerable<OggettoContenitore> ElencoOggSis { get; set; } = new List<OggettoContenitore>();


    }
}
