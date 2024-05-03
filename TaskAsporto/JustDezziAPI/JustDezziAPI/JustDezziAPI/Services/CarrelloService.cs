using JustDezziAPI.DTO;
using JustDezziAPI.Models;
using JustDezziAPI.Repo;

namespace JustDezziAPI.Services
{
    public class CarrelloService
    {
        private readonly CarrelloRepo _repository;
        public CarrelloService(CarrelloRepo repo)
        { _repository = repo; }

        public IEnumerable<Carrello> PrendiliTutti()
        {
            return _repository.GetAll();
        }
        public List<CarrelloDTO> RestituisciTutti()
        {
            List<CarrelloDTO> elenco = this.PrendiliTutti().Select(p => new CarrelloDTO()
            {
                UtenteRif=p.UtenteRif,
                Piatti=p.CarrelloPiattos
            }).ToList();
            return elenco;
        }

        public bool InserisciCarrello(CarrelloDTO carrelloDto)
        {
            if (_repository.GetByUtente(carrelloDto.UtenteRif) != null)
            {
                // Se esiste già un carrello per l'utente, non crearne uno nuovo
                return false;
            }
            Carrello carrello = new Carrello()
            {
                UtenteRif = carrelloDto.UtenteRif,
                
                CarrelloPiattos=carrelloDto.Piatti
            };

            return _repository.Create(carrello);
        }
        public Carrello? PrendiByID(int id)
        {
            return _repository.Get(id);
        }
        public Carrello? PrendiByUtente(int utenteRif)
        {
           
                Carrello? carrello = _repository.GetByUtente(utenteRif);
                if (carrello != null)
                    return carrello;
            
            return null;
                
            

        }
        public bool Elimina(CarrelloDTO carrelloDTO)
        {
            Carrello? carr = _repository.GetByUtente(carrelloDTO.UtenteRif);
            if (carr == null)
                return false;

            return _repository.Delete(carr.Id);
        }
        public bool Aggiorna(Carrello esistente, CarrelloDTO nuovo)
        {
            if (esistente.Id<0 || nuovo.UtenteRif <0)
            {
                esistente.UtenteRif = nuovo.UtenteRif;
                esistente.CarrelloPiattos = nuovo.Piatti;
                
                return _repository.Update(esistente);
            }
            return false;

        }
    }
}
