using System;
using System.Collections.Generic;

namespace JustDezziAPI.Models;

public partial class Ristorante
{
    public int Id { get; set; }

    public string Codice { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public TimeOnly Apertura { get; set; }

    public TimeOnly Chiusura { get; set; }

    public string Indirizzo { get; set; } = null!;

    public virtual ICollection<Ordinazione> Ordinaziones { get; set; } = new List<Ordinazione>();

    public virtual ICollection<Piatto> Piattos { get; set; } = new List<Piatto>();
}
