using JustDezziAPI.DTO;
using JustDezziAPI.Models;
using JustDezziAPI.Repo;

namespace JustDezziAPI.Services
{
    public class OrdinazioneService
    {
        private readonly OrdinazioneRepo _repository;
        public OrdinazioneService(OrdinazioneRepo repo)
        { _repository = repo; }

        public IEnumerable<Ordinazione> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<OrdinazioneDTO> RestituisciTutti()
        {
            List<OrdinazioneDTO> elenco = this.PrendiliTutti().Select(p => new OrdinazioneDTO()
            {
                Istruzioni=p.Istruzioni,
                Codice=p.Codice,
                CarrelloRif=p.CarrelloRif,
                RistoranteRif=p.RistoranteRif,
                UtenteRif=p.UtenteRif,
                DataOra=p.DataOra,
                Stato = p.Stato
            }).ToList();
            return elenco;
        }

        public bool InserisciOrdinazione(OrdinazioneDTO ordinazioneDto)
        {

            Ordinazione ordinazione = new Ordinazione()
            {
                UtenteRif = ordinazioneDto.UtenteRif,

                Istruzioni = ordinazioneDto.Istruzioni,
                Codice=ordinazioneDto.Codice,
                CarrelloRif=ordinazioneDto.CarrelloRif,
                Stato = ordinazioneDto.Stato,
                RistoranteRif = ordinazioneDto.RistoranteRif,
                
            };

            return _repository.Create(ordinazione);
        }

    }
}
