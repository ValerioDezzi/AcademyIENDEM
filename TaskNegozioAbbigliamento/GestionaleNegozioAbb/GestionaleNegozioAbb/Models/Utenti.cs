using System;
using System.Collections.Generic;

namespace GestionaleNegozioAbb.Models;

public partial class Utenti
{
    public int UtenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Ordini> Ordinis { get; set; } = new List<Ordini>();
}
