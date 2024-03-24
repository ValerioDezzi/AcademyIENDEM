using System;
using System.Collections.Generic;

namespace GestioneEventi.Models;

public partial class Risorsa
{
    public int RisorsaId { get; set; }

    public string Nome { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public int Quantita { get; set; }

    public decimal CostoUnitario { get; set; }

    public string Fornitore { get; set; } = null!;

    public int? EventoRif { get; set; }

    public virtual Evento? EventoRifNavigation { get; set; }

    public string EsportaCsv()
    {
        return $"{RisorsaId};{Nome};{Tipo};{Descrizione};{Quantita};{CostoUnitario};{Fornitore};{EventoRif}";
    }
}
