using System;
using System.Collections.Generic;

namespace GestioneImpiegati.Models;

public partial class Cittum
{
    public int Id { get; set; }

    public string NomeCitta { get; set; } = null!;

    public int? ProvinciaRif { get; set; }

    public virtual Provincium? ProvinciaRifNavigation { get; set; }
}
