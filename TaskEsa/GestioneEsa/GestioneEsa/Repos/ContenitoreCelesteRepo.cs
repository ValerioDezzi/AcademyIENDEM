using GestioneEsa.Models;
using System.Linq.Expressions;

namespace GestioneEsa.Repos
{
    public class ContenitoreCelesteRepo : IRepository<ContenitoreCeleste>
    {
        private readonly EsaContext _context;
        public ContenitoreCelesteRepo(EsaContext context)
        {
            _context = context;
        }


        public bool Create(ContenitoreCeleste entity)
        {
            try
            {
                _context.ContenitoreCelestes.Add(entity);
                _context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                ContenitoreCeleste? contenitore = Get(id);
                if (contenitore != null)
                {
                    _context.ContenitoreCelestes.Remove(contenitore);
                    _context.SaveChanges();
                    return true;
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return false;
        }

            public ContenitoreCeleste? Get(int id)
        {
            return _context.ContenitoreCelestes.Find(id); 
        }

        public IEnumerable<ContenitoreCeleste> GetAll()
        {
            return _context.ContenitoreCelestes.ToList();
        }

        public bool Update(ContenitoreCeleste entity)
        {
            try
            {
                _context.ContenitoreCelestes.Update(entity);
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
