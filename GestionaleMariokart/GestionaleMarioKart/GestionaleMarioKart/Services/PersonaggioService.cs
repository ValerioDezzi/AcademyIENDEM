 using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Repos;

namespace GestionaleMarioKart.Services
{
    public class PersonaggioService : IService<Personaggio>
    {
        private readonly PersonaggioRepo _repository;
        public PersonaggioService(PersonaggioRepo repository)
        {
            _repository = repository;
        }

        public bool Aggiorna(Personaggio entity)
        {
            return _repository.Update(entity);
        }

        public bool Elimina(PersonaggioDTO pers)
        {
            return _repository.Delete(_repository.GetByNome(pers.Nom).Id);
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
        public bool ModificaNome(PersonaggioDTO pers,string nuovoNome)
        {
            if (nuovoNome is not null && pers.Nom is not null)
            {
                Personaggio? temp = _repository.GetByNome(pers.Nom);
                if (temp is not null) {
                temp.NomePersonaggio = nuovoNome;
                return _repository.Update(temp);
                }
            }
            return false;
        }
    }
}
