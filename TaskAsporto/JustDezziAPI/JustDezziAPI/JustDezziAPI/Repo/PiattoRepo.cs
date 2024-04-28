using JustDezziAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JustDezziAPI.Repo
{
    public class PiattoRepo : IRepo<Piatto>
    {
        private readonly JustDezziContext _context;
        public PiattoRepo(JustDezziContext context)
        {
            _context = context;
        }
        public bool Create(Piatto entity)
        {
            try
            {
                _context.Piattos.Add(entity);
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
                Piatto? temp = Get(id);
                if (temp != null)
                {
                    _context.Piattos.Remove(temp);
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
    

        public Piatto? Get(int id)
        {
        return _context.Piattos.Find(id);
        }

        public IEnumerable<Piatto> GetAll()
        {
            return _context.Piattos.ToList();
        }
        public Piatto? GetByCodice(string codice)
        {
            Piatto? tmp = null;
            try
            {
                tmp = _context.Piattos.FirstOrDefault(u => u.Codice == codice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tmp;
        }

        public bool Update(Piatto entity)
        {
            try
            {
                _context.Piattos.Update(entity);
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
