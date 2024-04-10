
using GestioneEsa.Models;
using System.Linq.Expressions;

namespace GestioneEsa.Repos
{
    public class OggettoCelesteRepo : IRepository<OggettoCeleste>
    {
        private readonly EsaContext _context;
        public OggettoCelesteRepo(EsaContext context)
        {
            _context = context;
        }

        public bool Create(OggettoCeleste entity)
        {
            try
            {
                _context.OggettoCelestes.Add(entity);
                _context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                OggettoCeleste? oggetto = Get(id);
                if (oggetto != null)
                {
                    _context.OggettoCelestes.Remove(oggetto);
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

        public OggettoCeleste? Get(int id)
        {
            return _context.OggettoCelestes.Find(id);
        }

        public IEnumerable<OggettoCeleste> GetAll()
        {
            return _context.OggettoCelestes.ToList();
        }

        public bool Update(OggettoCeleste entity)
        {
            try
            {
                _context.OggettoCelestes.Update(entity);
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
