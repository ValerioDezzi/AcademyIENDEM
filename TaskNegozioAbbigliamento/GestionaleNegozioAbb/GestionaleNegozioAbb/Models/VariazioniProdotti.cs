using System;
using System.Collections.Generic;

namespace GestionaleNegozioAbb.Models;

public partial class VariazioniProdotti
{
    public int VariazioneId { get; set; }

    public string Colore { get; set; } = null!;

    public string Taglia { get; set; } = null!;

    public int Quantita { get; set; }

    public decimal PrezzoPieno { get; set; }

    public decimal? PrezzoOfferta { get; set; }

    public DateTime? DataInizioOfferta { get; set; }

    public DateTime? DataFineOfferta { get; set; }

    public int? ProdottoRif { get; set; }

    public virtual ICollection<DettagliOrdini> DettagliOrdinis { get; set; } = new List<DettagliOrdini>();

    public virtual Prodotti? ProdottoRifNavigation { get; set; }
}
