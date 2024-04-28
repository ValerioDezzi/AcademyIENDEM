using System;
using System.Collections.Generic;

namespace GestioneImpiegati.Models;

public partial class Provincium
{
    public int Id { get; set; }

    public string NomeProvincia { get; set; } = null!;

    public virtual ICollection<Cittum> Citta { get; set; } = new List<Cittum>();
}
