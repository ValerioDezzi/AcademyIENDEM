using GestionaleMarioKart.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionaleMarioKart.Repos
{
    public class SquadraRepo : IRepo<Squadra>
    {
        private readonly MariokartContext _context;

        public SquadraRepo(MariokartContext context)
        {
            _context = context;
        }
        public bool Create(Squadra entity)
        {
            try
            {
                _context.Squadras.Add(entity);
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
                Squadra? temp = Get(id);
                if (temp != null)
                {
                    _context.Squadras.Remove(temp);
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

        public Squadra? Get(int id)
        {
            return _context.Squadras.Find(id);
        }
        public Squadra GetByNome(string nome)
        {
            return _context.Squadras.First(s=>s.Nome==nome);
        }

        public IEnumerable<Squadra> GetAll()
        {
            return _context.Squadras.ToList();
        }
       

        public bool Update(Squadra entity)
        {
            try
            {
                _context.Squadras.Update(entity);
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
