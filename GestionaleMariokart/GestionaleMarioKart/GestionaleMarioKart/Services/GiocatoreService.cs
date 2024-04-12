using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Repos;

namespace GestionaleMarioKart.Services
{
    public class GiocatoreService : IService<Giocatore>
    {
        private readonly GiocatoreRepo _repository;
        public GiocatoreService(GiocatoreRepo repository)
        {
            _repository = repository;
        }

        public bool Aggiorna(Giocatore entity)
        {
            return _repository.Update(entity);
        }

        public bool Elimina(GiocatoreDTO gioc)
        {
            return _repository.Delete(_repository.GetByNome(gioc.Nom).Id);
        }

        public bool Inserisci(GiocatoreDTO oGio)
        {
            Giocatore gio = new Giocatore()
            {
                NomeGiocatore = oGio.Nom,
                

            };
            return _repository.Create(gio);
        }

        public Giocatore? PrendiByID(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Giocatore> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<GiocatoreDTO> RestituisciTutti()
        {

            List<GiocatoreDTO> elenco = this.PrendiliTutti().Select(p => new GiocatoreDTO()
            {
                Nom = p.NomeGiocatore,
                
            }).ToList();

            return elenco;
        }

        
    }
}
