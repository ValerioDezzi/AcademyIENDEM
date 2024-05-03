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
