using System.Text.Json.Serialization;

namespace GestioneEsa.Models
{
    public class OggettoContenitore
    {
        [JsonIgnore]
        public ContenitoreCeleste con { get; set; } = null!;
        
        public OggettoCeleste oggetto { get; set; }=null!;
        [JsonIgnore]
        public int ContenitoreRif {  get; set; }
        
        public int OggettoRif { get;set; }
    }
}
