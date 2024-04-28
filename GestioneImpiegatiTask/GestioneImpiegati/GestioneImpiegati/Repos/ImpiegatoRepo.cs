using GestioneImpiegati.Models;

namespace GestioneImpiegati.Repos
{
    public class ImpiegatoRepo : IRepo<Impiegati>
    {
        private readonly GestioneImpiegatiContext _context;
        public ImpiegatoRepo(GestioneImpiegatiContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Impiegati> GetAll()
        {
            return _context.Impiegatis.ToList();
        }

        public Impiegati? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Impiegati t)
        {
            try
            {
                _context.Impiegatis.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool Update(Impiegati t)
        {
            throw new NotImplementedException();
        }
    }
}
