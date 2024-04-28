using GestFerrAuth.DTO;
using GestFerrAuth.Models;
using GestFerrAuth.Repos;

namespace GestFerrAuth.Services
{
    public class ProdottoService 
    {
        private readonly ProdottoRepo _repository;

        public ProdottoService(ProdottoRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<Prodotto> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<ProdottoDto> RestituisciTutti()
        {
            List<ProdottoDto> elenco = this.PrendiliTutti().Select(p => new ProdottoDto()
            {
                Nom = p.Nome,
                Cat = p.Categoria,
                Cod = p.Codice,
                Des = p.Descrizione,
                Pre = p.Prezzo,
                Qua = p.Quantita
            }).ToList();

            return elenco;
        }


        public List<ProdottoDto> RestituisciProdottiFiltrati()
        {
            List<ProdottoDto> elenco = this.PrendiliTutti()
                .Where(e => e.Categoria != "VM")
                .Select(p => new ProdottoDto()
                {
                    Nom = p.Nome,
                    Cat = p.Categoria,
                    Cod = p.Codice,
                    Des = p.Descrizione,
                    Pre = p.Prezzo,
                    Qua = p.Quantita
                })
                .ToList();

            return elenco;
        }

        public bool InserisciProdotto(ProdottoDto oPro)
        {
            Prodotto pro = new Prodotto()
            {
                Categoria = oPro.Cat,
                Codice = oPro.Cod,
                Descrizione = oPro.Des,
                Nome = oPro.Nom,
                Quantita = oPro.Qua,
                Prezzo = oPro.Pre,
                DataCreazione = DateTime.Now
            };

            return _repository.Create(pro);
        }
        public Prodotto? PrendiByID(int id)
        {
            return _repository.Get(id);
        }
        public ProdottoDto? PrendiByCodice(ProdottoDto obj)
        {
            if(obj.Cod != null)
            {
                Prodotto? pro= _repository.GetByCodice(obj.Cod);
                if (pro != null)
                    return new ProdottoDto()
                    {
                        Cod = pro.Codice,
                        Cat = pro.Categoria,
                        Des = pro.Descrizione,
                        Pre = pro.Prezzo,
                        Qua = pro.Quantita,
                        Nom = pro.Nome

                    };
            }
            return null;
           
        }
        public bool Elimina(ProdottoDto prod)
        {
            Prodotto? temp=_repository.GetByCodice(prod.Cod);
            if (temp == null)
                return false;

            return _repository.Delete(_repository.GetByCodice(prod.Cod).Id);
        }
        public bool Aggiorna(ProdottoDto vecchio,ProdottoDto nuovo)
        {
            vecchio.Cod = nuovo.Cod;
            vecchio.Cat= nuovo.Cat;
            vecchio.Des= nuovo.Des;
            vecchio.Nom= nuovo.Nom;
            vecchio.Pre= nuovo.Pre;
            vecchio.Qua= nuovo.Qua;

            return _repository.Update(new Prodotto()
            {
                Codice=vecchio.Cod,
                Categoria=vecchio.Nom,
                Descrizione=vecchio.Des,
                Nome=vecchio.Cat,
                Prezzo=vecchio.Pre,
                Quantita=vecchio.Qua
            });
        }
    }
}