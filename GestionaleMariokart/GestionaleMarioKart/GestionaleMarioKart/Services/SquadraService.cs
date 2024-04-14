using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Repos;

namespace GestionaleMarioKart.Services
{
    public class SquadraService : IService<Squadra>
    {
        private readonly SquadraRepo _repository;
        public SquadraService(SquadraRepo repository)
        {
            _repository = repository;
        }

        public bool Aggiorna(Squadra entity)
        {
            return _repository.Update(entity);
        }

        public bool Elimina(SquadraDTO squa)
        {
            return _repository.Delete(_repository.GetByNome(squa.Nome).Id);
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

        public bool ModificaNome(SquadraDTO squa, string nuovoNome)
        {
            if (squa.Nome is not null)
            {
                Squadra? temp = _repository.GetByNome(squa.Nome);
                if (temp is not null)
                {
                    temp.Nome = nuovoNome;
                    return _repository.Update(temp);

                }
            }
            return false;
        }
    }
}
