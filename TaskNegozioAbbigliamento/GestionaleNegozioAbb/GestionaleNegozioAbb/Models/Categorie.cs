using System;
using System.Collections.Generic;

namespace GestionaleNegozioAbb.Models;

public partial class Categorie
{
    public int CategoriaId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Prodotti> ProdottoRifs { get; set; } = new List<Prodotti>();
}
