using JustDezziAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JustDezziAPI.Repo
{
    public class CarrelloRepo : IRepo<Carrello>
    {
        private readonly JustDezziContext _context;
        public CarrelloRepo(JustDezziContext context)
        {
            _context = context;
        }
        public bool Create(Carrello entity)
        {
            try
            {
                _context.Carrellos.Add(entity);
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
                Carrello? temp = Get(id);
                if (temp != null)
                {
                    _context.Carrellos.Remove(temp);
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
    

        public Carrello? Get(int id)
        {
            return _context.Carrellos.Find(id);
        }

        public IEnumerable<Carrello> GetAll()
        {
            return _context.Carrellos.Include(c=>c.CarrelloPiattos).ToList();
            
        }
        public Carrello? GetByUtente(int utenteRIF)
        {
            return _context.Carrellos
                   .Include(c => c.CarrelloPiattos) // Include i dati relativi a CarrelloPiattos
                   .FirstOrDefault(c => c.UtenteRif == utenteRIF);
            //Carrello? tmp = null;
            //try
            //{
            //    tmp = _context.Carrellos.FirstOrDefault(u => u.UtenteRif == utenteRIF);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //return tmp;
        }

        public bool Update(Carrello entity)
        {
            try
            {
                _context.Carrellos.Update(entity);
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
