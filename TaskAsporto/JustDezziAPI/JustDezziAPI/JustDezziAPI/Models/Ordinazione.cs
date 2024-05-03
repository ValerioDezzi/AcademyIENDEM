using System;
using System.Collections.Generic;

namespace JustDezziAPI.Models;

public partial class Ordinazione
{
    public int Id { get; set; }

    public string Codice { get; set; } = null!;

    public DateTime? DataOra { get; set; }

    public string? Istruzioni { get; set; }

    public string Stato { get; set; } = null!;

    public int UtenteRif { get; set; }

    public int RistoranteRif { get; set; }

    public int CarrelloRif { get; set; }

    public virtual Carrello CarrelloRifNavigation { get; set; } = null!;

    public virtual Ristorante RistoranteRifNavigation { get; set; } = null!;

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
