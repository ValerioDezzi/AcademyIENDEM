using System;
using System.Collections.Generic;

namespace GestionaleNegozioAbb.Models;

public partial class Prodotti
{
    public int ProdottoId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public string? ImmagineUrl { get; set; }

    public virtual ICollection<VariazioniProdotti> VariazioniProdottis { get; set; } = new List<VariazioniProdotti>();

    public virtual ICollection<Categorie> CategoriaRifs { get; set; } = new List<Categorie>();
}
