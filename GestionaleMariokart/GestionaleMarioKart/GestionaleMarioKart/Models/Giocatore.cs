using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionaleMarioKart.Models
{
    [Table("Giocatore")]
    public class Giocatore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeGiocatore { get; set; } = null!;
       
        public int CreditiBudget { get; set; } = 10;

        public Squadra? Squadra { get; set; }
    }
}
