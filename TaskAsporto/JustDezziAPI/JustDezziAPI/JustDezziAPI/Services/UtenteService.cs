using JustDezziAPI.DTO;
using JustDezziAPI.Models;
using JustDezziAPI.Repo;

namespace JustDezziAPI.Services
{
    public class UtenteService
    {
        private readonly UtenteRepo _repository;
        public UtenteService(UtenteRepo repo)
        {  _repository = repo; }

        public IEnumerable<Utente> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<UtenteDTO> RestituisciTutti()
        {
            List<UtenteDTO> elenco = this.PrendiliTutti().Select(p => new UtenteDTO()
            {
                Nom = p.Nome,
                Pas = p.Pass,
                Ema= p.Email,
                Ind= p.Indirizzo
            }).ToList();

            return elenco;
        }
        public bool InserisciUtente(UtenteDTO utenteDto)
        {
            Utente utente = new Utente()
                  {
                  Nome=utenteDto.Nom,
                  Pass=utenteDto.Pas,
                  Email=utenteDto.Ema,
                  Indirizzo= utenteDto.Ind,
                  
                
                  };

            return _repository.Create(utente);
        }
        public Utente? PrendiByID(int id)
        {
            return _repository.Get(id);
        }
        public Utente? PrendiByNome(string nome)
        {
            if (nome != null)
            {
                Utente? ute = _repository.GetByNome(nome);
                if (ute != null)
                    return ute;
            }
            return null;

        }
        public bool Elimina(UtenteDTO ute)
        {
            Utente? temp = _repository.GetByNome(ute.Nom);
            if (temp == null)
                return false;

            return _repository.Delete(_repository.GetByNome(ute.Nom).Id);
        }
        public bool Aggiorna( UtenteDTO nuovo)
        {
           
                return _repository.Update(new Utente()
                {
                    Nome = nuovo.Nom,
                    Email=nuovo.Ema,
                    Indirizzo= nuovo.Ind,
                    Pass=nuovo.Pas
                });
        }
    }
}
