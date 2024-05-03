using JustDezziAPI.Models;

namespace JustDezziAPI.Repo
{
    public class OrdinazioneRepo : IRepo<Ordinazione>
    {
        private readonly JustDezziContext _context;
        public OrdinazioneRepo(JustDezziContext context)
        {
            _context = context;
        }

        public bool Create(Ordinazione entity)
        {
            try
            {
                _context.Ordinaziones.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Ordinazione? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ordinazione> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Ordinazione entity)
        {
            throw new NotImplementedException();
        }
    }
}
