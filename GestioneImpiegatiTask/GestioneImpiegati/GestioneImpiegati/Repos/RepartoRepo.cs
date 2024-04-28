using GestioneImpiegati.Models;

namespace GestioneImpiegati.Repos
{
    public class RepartoRepo : IRepo<Reparto>
    {
        private readonly GestioneImpiegatiContext _context;
        public RepartoRepo(GestioneImpiegatiContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reparto> GetAll()
        {
           return _context.Repartos.ToList();
        }

        public Reparto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Reparto t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reparto t)
        {
            throw new NotImplementedException();
        }
    }
}
