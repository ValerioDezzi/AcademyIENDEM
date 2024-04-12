using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Repos;

namespace GestionaleMarioKart.Services
{
    public class SquadraService : IService<Squadra>
    {
        private readonly IRepo<Squadra> _repository;
        public SquadraService(IRepo<Squadra> repository)
        {
            _repository = repository;
        }

        public bool Aggiorna(Squadra entity)
        {
            return _repository.Update(entity);
        }

        public bool Elimina(int id)
        {
            return _repository.Delete(id);
        }

        public bool Inserisci(SquadraDTO oSqua)
        {
            Squadra squa = new Squadra()
            {
                Nome = oSqua.Nome,
                GiocatoreRif = oSqua.Gioc,
                Personaggio50Rif=oSqua.Pers50,
                Personaggio100Rif=oSqua.Pers100,
                Personaggio150Rif=oSqua.Pers150,
            };
            return _repository.Create(squa);
        }

        public Squadra? PrendiByID(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Squadra> PrendiliTutti()
        {
            return _repository.GetAll();
        }
        public List<Squadra> RestituisciTutti()
        {
            return this.PrendiliTutti().ToList();

        }
        
    }
}
