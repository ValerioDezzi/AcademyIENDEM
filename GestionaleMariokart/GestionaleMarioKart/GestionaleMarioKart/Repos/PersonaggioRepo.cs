using GestionaleMarioKart.Models;

namespace GestionaleMarioKart.Repos
{
    public class PersonaggioRepo : IRepo<Personaggio>
    {
        private readonly MariokartContext _context;
        public PersonaggioRepo(MariokartContext context)
        {
            _context = context;
        }

        public bool Create(Personaggio entity)
        {
            try
            {
                _context.Personaggios.Add(entity);
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
            try
            {
                Personaggio? temp = Get(id);
                if (temp != null)
                {
                    _context.Personaggios.Remove(temp);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return false;
        }

        public Personaggio? Get(int id)
        {
            return _context.Personaggios.Find(id);
        }

        public IEnumerable<Personaggio> GetAll()
        {
            return _context.Personaggios.ToList();
        }

        public bool Update(Personaggio entity)
        {
            try
            {
                _context.Personaggios.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
