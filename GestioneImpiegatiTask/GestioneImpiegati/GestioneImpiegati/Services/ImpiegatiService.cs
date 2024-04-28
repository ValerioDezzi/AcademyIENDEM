using GestioneImpiegati.Models;
using GestioneImpiegati.Repos;

namespace GestioneImpiegati.Services
{
    public class ImpiegatiService
    {
        private readonly ImpiegatoRepo _repository;
        public ImpiegatiService(ImpiegatoRepo repo) 
        {
            _repository = repo;
        }   

        public bool InserisciImpiegato(Impiegati imp)
        {
            return _repository.Insert(imp);
        }
        public List<Impiegati> ElencoImpiegati()
        { 
            return _repository.GetAll();
        }
    }
}
