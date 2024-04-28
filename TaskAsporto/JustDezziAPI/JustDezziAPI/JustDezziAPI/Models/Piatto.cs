using System;
using System.Collections.Generic;

namespace JustDezziAPI.Models;

public partial class Piatto
{
    public int Id { get; set; }

    public string Codice { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public decimal Prezzo { get; set; }

    public int RistoranteRif { get; set; }

    public virtual ICollection<CarrelloPiatto> CarrelloPiattos { get; set; } = new List<CarrelloPiatto>();

    public virtual Ristorante RistoranteRifNavigation { get; set; } = null!;
}
