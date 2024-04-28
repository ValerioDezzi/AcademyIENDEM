using System;
using System.Collections.Generic;

namespace JustDezziAPI.Models;

public partial class Carrello
{
    public int Id { get; set; }

    public int UtenteRif { get; set; }

    public virtual ICollection<CarrelloPiatto> CarrelloPiattos { get; set; } = new List<CarrelloPiatto>();

    public virtual ICollection<Ordinazione> Ordinaziones { get; set; } = new List<Ordinazione>();

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
