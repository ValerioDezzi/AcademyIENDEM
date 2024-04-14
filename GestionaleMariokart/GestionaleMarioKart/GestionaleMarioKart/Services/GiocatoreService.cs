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
        public Giocatore PrendiByNome(GiocatoreDTO gioc)
        {
            return _repository.GetByNome(gioc.Nom);
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
        public bool ModificaNome(GiocatoreDTO gioc,string nuovoNome)
        {
            if(gioc.Nom is not null)
            {
                Giocatore? temp = _repository.GetByNome(gioc.Nom);
                if (temp is not null)
                {
                    temp.NomeGiocatore=nuovoNome;
                    return _repository.Update(temp);
                    
                }
            }
            return false;
        }

        
    }
}
