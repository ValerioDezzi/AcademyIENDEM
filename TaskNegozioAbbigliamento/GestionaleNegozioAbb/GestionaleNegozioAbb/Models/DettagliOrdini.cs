using System;
using System.Collections.Generic;

namespace GestionaleNegozioAbb.Models;

public partial class DettagliOrdini
{
    public int DettaglioId { get; set; }

    public int? OrdineRif { get; set; }

    public int? VariazioneRif { get; set; }

    public int Quantita { get; set; }

    public virtual Ordini? OrdineRifNavigation { get; set; }

    public virtual VariazioniProdotti? VariazioneRifNavigation { get; set; }
}
