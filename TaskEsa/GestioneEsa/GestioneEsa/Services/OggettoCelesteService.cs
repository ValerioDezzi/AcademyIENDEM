using GestioneEsa.Models;
using GestioneEsa.Repos;

namespace GestioneEsa.Services
{
    public class OggettoCelesteService : IService<OggettoCeleste>
    {
        private readonly IRepository<OggettoCeleste> _repository;
        public OggettoCelesteService(IRepository<OggettoCeleste> repository)
        {
            _repository = repository;
        }

        public OggettoCeleste? PrendiById(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<OggettoCeleste> PrendiliTutti()
        {
            return _repository.GetAll();
        }
    }
}
