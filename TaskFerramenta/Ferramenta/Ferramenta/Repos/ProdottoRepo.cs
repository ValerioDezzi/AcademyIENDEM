using Ferramenta.Models;
using Ferramenta.Repos;

namespace Ferramenta.Repos
{
    public class ProdottoRepo : IRepo<Prodotti>
    {
        private static ProdottoRepo? _instance;
        public static ProdottoRepo getInstance()
        {
            if (_instance == null)
                _instance = new ProdottoRepo();
            return _instance;
        }
        public ProdottoRepo() { }

      

        public List<Prodotti> GetAll()
        {
            List<Prodotti> elenco= new List<Prodotti>();
            using (FerramentaContext ctx = new FerramentaContext())
            {
                elenco = ctx.Prodottis.ToList();
            }

            return elenco;
        }

        public Prodotti? Get(string codice)
        {
            Prodotti? prod = null;

            using (FerramentaContext ctx = new FerramentaContext())
                prod = ctx.Prodottis.FirstOrDefault(p => p.Codice == codice);

            return prod;
        }

        public bool Insert(Prodotti t)
        {
            bool risultato = false;
            using (FerramentaContext ctx = new FerramentaContext())
            {
                try
                {
                    ctx.Prodottis.Add(t);
                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }

        public bool Update(Prodotti t)
        {
            bool risultato = false;

            using (FerramentaContext ctx = new FerramentaContext())
            {
                try
                {
                    Prodotti temp = ctx.Prodottis.Single(p => p.Codice == t.Codice);

                    t.ProdottoId = temp.ProdottoId;
                    t.Codice = t.Codice is not null ? t.Codice : temp.Codice;
                    t.Nome = t.Nome is not null ? t.Nome : temp.Nome;
                    t.Descrizione = t.Descrizione is not null ? t.Descrizione : temp.Descrizione;
                    t.Prezzo = t.Prezzo == 0 ? temp.Prezzo : t.Prezzo;
                    t.Quantita = temp.Quantita;

                    ctx.Entry(temp).CurrentValues.SetValues(t);

                    ctx.SaveChanges();

                    risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }

        public bool Delete(string codice)
        {
            bool risultato = false;
            using (FerramentaContext ctx = new FerramentaContext())
            {
                try
                {
                    Prodotti prod = ctx.Prodottis.Single(p => p.Codice == codice);
                    ctx.Prodottis.Remove(prod);
                    ctx.SaveChanges();

                    risultato = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return risultato;
        }
    }
}
