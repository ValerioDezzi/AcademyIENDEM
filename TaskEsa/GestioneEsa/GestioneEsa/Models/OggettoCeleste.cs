namespace GestioneEsa.Models
{
    public class OggettoCeleste
    {
        public int OggettoId { get; set; }

        public string Codice { get; set; } = Guid.NewGuid().ToString().ToUpper();

        public string Nome { get; set; } = null!;

        public DateTime DataScoperta { get; set; }

        public string Scopritore { get; set; } = "N.D"!;

        public string Tipologia { get; set; } = "N.D"!;

        public long DistanzaTerra { get; set; }
        public float CoordinataModulo {  get; set; }
        public float CoordinataAzimut { get; set; }
        public IEnumerable<OggettoContenitore> ElencoOggCont { get; set; } = new List<OggettoContenitore>();
    }
}
