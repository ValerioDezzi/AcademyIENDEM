using System;
using System.Collections.Generic;

namespace GestioneEventi.Models;

public partial class Evento
{
    public int EventoId { get; set; }

    public string NomeEvento { get; set; } = null!;

    public string Descrizione { get; set; } = null!;

    public DateTime DataEvento { get; set; }

    public string Luogo { get; set; } = null!;

    public int CapacitaMax { get; set; }

    public virtual ICollection<Partecipante> Partecipantes { get; set; } = new List<Partecipante>();

    public virtual ICollection<Risorsa> Risorsas { get; set; } = new List<Risorsa>();
}
