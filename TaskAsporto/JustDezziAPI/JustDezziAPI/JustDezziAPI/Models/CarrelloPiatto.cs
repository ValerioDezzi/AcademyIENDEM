using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JustDezziAPI.Models;

public partial class CarrelloPiatto
{
    [JsonIgnore]
    public int? CarrelloRif { get; set; }

    public int PiattoRif { get; set; }

    public int Quantita { get; set; }
    [JsonIgnore]
    public virtual Carrello? CarrelloRifNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Piatto? PiattoRifNavigation { get; set; } = null!;
}
