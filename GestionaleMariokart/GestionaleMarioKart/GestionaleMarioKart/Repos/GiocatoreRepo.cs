using GestionaleMarioKart.Models;
using System.Runtime.CompilerServices;

namespace GestionaleMarioKart.Repos
{
    public class GiocatoreRepo : IRepo<Giocatore>
    {
        private readonly MariokartContext _context;
        public GiocatoreRepo(MariokartContext context)
        {
            _context = context;
        }

        public bool Create(Giocatore entity)
        {
            _context.Giocatores.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                Giocatore? temp = Get(id);
                if (temp != null)
                {
                    _context.Giocatores.Remove(temp);
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

        public Giocatore? Get(int id)
        {
            return _context.Giocatores.Find(id);
        }
        public Giocatore GetByNome(string nome)
        {
            return _context.Giocatores.First(g=>g.NomeGiocatore==nome);
        }

        public IEnumerable<Giocatore> GetAll()
        {
            return _context.Giocatores.ToList();
        }

        public bool Update(Giocatore entity)
        {
            try
            {
                _context.Giocatores.Update(entity);
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
