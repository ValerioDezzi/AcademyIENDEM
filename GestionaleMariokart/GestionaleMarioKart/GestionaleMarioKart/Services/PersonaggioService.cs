using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Repos;

namespace GestionaleMarioKart.Services
{
    public class PersonaggioService : IService<Personaggio>
    {
        private readonly IRepo<Personaggio> _repository;
        public PersonaggioService(IRepo<Personaggio> repository)
        {
            _repository = repository;
        }

        public bool Aggiorna(Personaggio entity)
        {
            return _repository.Update(entity);
        }

        public bool Elimina(int id)
        {
            return _repository.Delete(id);
        }

        public bool Inserisci(PersonaggioDTO oPers)
        {
            Personaggio pers = new Personaggio()
            {
                NomePersonaggio=oPers.Nom,
                Costo= oPers.Cost,
                Categoria=oPers.Cat,
            };
            return _repository.Create(pers);
        }

        public Personaggio? PrendiByID(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Personaggio> PrendiliTutti()
        {
            return _repository.GetAll();
        }
        public List<Personaggio> RestituisciTutti()
        {
            return this.PrendiliTutti().ToList();

        }
    }
}
