using System;
using System.Collections.Generic;

namespace GestioneImpiegati.Models;

public partial class Impiegati
{
    public int Id { get; set; }

    public string? Matricola { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateOnly DataNascita { get; set; }

    public string? Ruolo { get; set; }

    public string Reparto { get; set; } = null!;

    public string Indirizzo { get; set; } = null!;

    public string Citta { get; set; } = null!;
}
