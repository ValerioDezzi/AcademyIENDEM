
using GestioneEsa.Models;
using GestioneEsa.Repos;

namespace GestioneEsa.Services
{
    public class ContenitoreCelesteService : IService<ContenitoreCeleste>
    {
        private readonly IRepository<ContenitoreCeleste> _repository;
        public ContenitoreCelesteService(IRepository<ContenitoreCeleste> repository)
        {
            _repository = repository;
        }


        public ContenitoreCeleste? PrendiById(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<ContenitoreCeleste> PrendiliTutti()
        {
            return _repository.GetAll();
        }
    }
}
