using GestioneImpiegati.Models;
using GestioneImpiegati.Repos;

namespace GestioneImpiegati.Services
{
    public class RepartoService
    {
        private readonly RepartoRepo _repo;
        public RepartoService(RepartoRepo repo)
        {
            _repo = repo;
        }
        public List<Reparto> ElencoTuttiReparti()
        {
            return _repo.GetAll();
        }
    }
}
