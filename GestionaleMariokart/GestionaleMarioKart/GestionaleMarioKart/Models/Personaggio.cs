using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionaleMarioKart.Models
{
    [Table("Personaggio")]
    public class Personaggio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NomePersonaggio { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Categoria { get; set; } = null!;
        [Range(1, 4)]
        public int Costo { get; set; }
        public ICollection<Squadra>? Squadre { get; set; }
    }
}


