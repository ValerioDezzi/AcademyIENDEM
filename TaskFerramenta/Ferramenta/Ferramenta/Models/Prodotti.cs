using System;
using System.Collections.Generic;

namespace Ferramenta.Models;

public partial class Prodotti
{
    public int ProdottoId { get; set; }

    public string Codice { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public decimal Prezzo { get; set; }

    public int Quantita { get; set; }

    public string Categoria { get; set; } = null!;

    public DateTime? DataCreazione { get; set; }
}
