using JustDezziAPI.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                Ordinazione? temp = Get(id);
                if (temp != null)
                {
                    _context.Ordinaziones.Remove(temp);
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

        public Ordinazione? Get(int id)
        {
            return _context.Ordinaziones.Find(id);
        }

        public IEnumerable<Ordinazione> GetAll()
        {
            return _context.Ordinaziones.Include(c=>c.CarrelloRifNavigation).ToList();
        }

        public bool Update(Ordinazione entity)
        {
            try
            {
                _context.Ordinaziones.Update(entity);
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
