using System;
using System.Collections.Generic;

namespace GestionaleNegozioAbb.Models;

public partial class Ordini
{
    public int OrdineId { get; set; }

    public DateTime? DataOrdine { get; set; }

    public int? UtenteRif { get; set; }

    public virtual ICollection<DettagliOrdini> DettagliOrdinis { get; set; } = new List<DettagliOrdini>();

    public virtual Utenti? UtenteRifNavigation { get; set; }
}
