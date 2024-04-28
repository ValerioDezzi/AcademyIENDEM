using System;
using System.Collections.Generic;

namespace JustDezziAPI.Models;

public partial class Utente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Indirizzo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Carrello> Carrellos { get; set; } = new List<Carrello>();

    public virtual ICollection<Ordinazione> Ordinaziones { get; set; } = new List<Ordinazione>();
}
