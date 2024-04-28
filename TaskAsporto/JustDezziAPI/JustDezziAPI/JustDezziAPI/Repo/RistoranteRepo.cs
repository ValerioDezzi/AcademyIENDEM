using JustDezziAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JustDezziAPI.Repo
{
    public class RistoranteRepo : IRepo<Ristorante>
    {
        private readonly JustDezziContext _context;
        public RistoranteRepo(JustDezziContext context)
        {
            _context = context;
        }
        public bool Create(Ristorante entity)
        {
            try
            {
                _context.Ristorantes.Add(entity);
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
                Ristorante? temp = Get(id);
                if (temp != null)
                {
                    _context.Ristorantes.Remove(temp);
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
    

        public Ristorante? Get(int id)
        {
        return _context.Ristorantes.Find(id);
        }

        public IEnumerable<Ristorante> GetAll()
        {
            return _context.Ristorantes.ToList();
        }

        public bool Update(Ristorante entity)
        {
            try
            {
                _context.Ristorantes.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public Ristorante? GetByCodice(string codice)
        {
            Ristorante? tmp = null;
            try
            {
                tmp = _context.Ristorantes.FirstOrDefault(u => u.Codice == codice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tmp;
        }
    }
}
