using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionaleMarioKart.Models
{
    [Table("Squadra")]
    public class Squadra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = null!;

        [ForeignKey("Personaggio50")]
        public int Personaggio50Rif { get; set; }
        public Personaggio Personaggio50 { get; set; } = null!;

        [ForeignKey("Personaggio100")]
        public int Personaggio100Rif { get; set; }
        public Personaggio Personaggio100 { get; set; } = null!;

        [ForeignKey("Personaggio150")]
        public int Personaggio150Rif { get; set; }
        public Personaggio Personaggio150 { get; set; }=null!;


        [ForeignKey("Giocatore")]
        public int GiocatoreRif { get; set; }
        public Giocatore Giocatore { get; set; } = null!;


        public int? CostoSquadra { get; set; }
        public List<Personaggio> PersonaggiScelti { get; set; } = null!;
        
    }
}
