using System;
using System.Collections.Generic;

namespace JustDezziAPI.Models;

public partial class CarrelloPiatto
{
    public int CarrelloRif { get; set; }

    public int PiattoRif { get; set; }

    public int Quantita { get; set; }

    public virtual Carrello CarrelloRifNavigation { get; set; } = null!;

    public virtual Piatto PiattoRifNavigation { get; set; } = null!;
}
