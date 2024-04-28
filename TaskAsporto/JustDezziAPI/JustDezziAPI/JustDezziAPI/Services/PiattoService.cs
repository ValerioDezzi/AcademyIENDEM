using JustDezziAPI.DTO;
using JustDezziAPI.Models;
using JustDezziAPI.Repo;

namespace JustDezziAPI.Services
{
    public class PiattoService
    {
        private readonly PiattoRepo _repository;
        public PiattoService(PiattoRepo repo)
        { _repository = repo; }
        public IEnumerable<Piatto> PrendiliTutti()
        {
            return _repository.GetAll();
        }
        public List<PiattoDTO> RestituisciTutti()
        {
            List<PiattoDTO> elenco = this.PrendiliTutti().Select(p => new PiattoDTO()
            {
                Cod = p.Codice,
                Nom = p.Nome,
                Des=p.Descrizione,
                Pre=p.Prezzo
            }).ToList();
            return elenco;
        }
        public bool InserisciPiatto(PiattoDTO piattoDto)
        {
            Piatto piatto = new Piatto()
            {
                Codice = piattoDto.Cod,
                Nome = piattoDto.Nom,
                Prezzo = piattoDto.Pre,
                Descrizione = piattoDto.Des,
                RistoranteRif = piattoDto.RistoranteRif

            };

              

            return _repository.Create(piatto);
        }
        public Piatto? PrendiByID(int id)
        {
            return _repository.Get(id);
        }
        public Piatto? PrendiByCodice(string cod)
        {
            if (cod != null)
            {
                Piatto? rist = _repository.GetByCodice(cod);
                if (rist != null)
                    return rist;
            }
            return null;

        }
        public bool Elimina(PiattoDTO piattoDTO)
        {
            Piatto? rist = _repository.GetByCodice(piattoDTO.Cod);
            if (rist == null)
                return false;

            return _repository.Delete(rist.Id);
        }
        public bool Aggiorna(Piatto esistente, PiattoDTO nuovo)
        {
            if (esistente.Codice is not null || nuovo.Cod is not null)
            {
                esistente.Codice = nuovo.Cod;
                esistente.Nome = nuovo.Nom;
                esistente.Descrizione = nuovo.Des;
                esistente.Prezzo = nuovo.Pre;
                esistente.RistoranteRif = nuovo.RistoranteRif;
                return _repository.Update(esistente);
            }
            return false;

        }
    }
}
