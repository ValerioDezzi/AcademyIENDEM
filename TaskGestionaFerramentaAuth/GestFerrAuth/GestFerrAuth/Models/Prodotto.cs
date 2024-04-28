using System;
using System.Collections.Generic;

namespace GestFerrAuth.Models;

public partial class Prodotto
{
    public int Id { get; set; }

    public string Codice { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public string Categoria { get; set; } = null!;

    public decimal Prezzo { get; set; }

    public int Quantita { get; set; }

    public DateTime? DataCreazione { get; set; }
}
