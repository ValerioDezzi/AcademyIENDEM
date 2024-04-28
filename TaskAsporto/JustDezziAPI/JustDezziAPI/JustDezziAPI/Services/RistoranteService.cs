using JustDezziAPI.DTO;
using JustDezziAPI.Models;
using JustDezziAPI.Repo;

namespace JustDezziAPI.Services
{
    public class RistoranteService
    {
        private readonly RistoranteRepo _repository;
        public RistoranteService(RistoranteRepo repo)
        { _repository = repo; }
        public IEnumerable<Ristorante> PrendiliTutti()
        {
            return _repository.GetAll();
        }
        public List<RistoranteDTO> RestituisciTutti()
        {
            List<RistoranteDTO> elenco = this.PrendiliTutti().Select(p => new RistoranteDTO()
            {
                Cod=p.Codice,
                Nom=p.Nome,
                Ind=p.Indirizzo,
                Tip=p.Tipo,
                Ape=p.Apertura,
                Chi=p.Chiusura
                
                
            }).ToList();

            return elenco;
        }
        public bool InserisciRistorante(RistoranteDTO ristoDto)
        {
            Ristorante risto = new Ristorante()

            {
                Codice = ristoDto.Cod,
                Nome = ristoDto.Nom,
                Tipo = ristoDto.Tip,
                Indirizzo = ristoDto.Ind,
                Apertura=ristoDto.Ape,
                Chiusura=ristoDto.Chi,


            };

            return _repository.Create(risto);
        }
        public Ristorante? PrendiByID(int id)
        {
            return _repository.Get(id);
        }
        public Ristorante? PrendiByCodice(string cod)
        {
            if (cod != null)
            {
                Ristorante? rist = _repository.GetByCodice(cod);
                if (rist != null)
                    return rist;
            }
            return null;

        }
        public bool Elimina(RistoranteDTO ristDTO)
        {
            Ristorante? rist = _repository.GetByCodice(ristDTO.Cod);
            if (rist == null)
                return false;

            return _repository.Delete(rist.Id);
        }
        public bool Aggiorna(Ristorante esistente, RistoranteDTO nuovo)
        {
            if (esistente.Nome is not null || nuovo.Cod is not null)
            {
                esistente.Codice = nuovo.Cod;
                esistente.Nome = nuovo.Nom;
                esistente.Apertura = nuovo.Ape;
                esistente.Chiusura = nuovo.Chi;
                esistente.Tipo = nuovo.Tip;
                esistente.Indirizzo = nuovo.Ind;
                return _repository.Update(esistente);
            }
            return false;

        }
    }
}
