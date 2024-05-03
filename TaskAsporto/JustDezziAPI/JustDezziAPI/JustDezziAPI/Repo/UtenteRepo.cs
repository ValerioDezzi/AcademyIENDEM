using JustDezziAPI.Models;

namespace JustDezziAPI.Repo
{
    public class UtenteRepo : IRepo<Utente>
    {
        private readonly JustDezziContext _context;
        public UtenteRepo(JustDezziContext context)
        {
            _context = context;
        }
        public bool Create(Utente entity)
        {
            try
            {
                _context.Utentes.Add(entity);
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
                Utente? temp = Get(id);
                if (temp != null)
                {
                    _context.Utentes.Remove(temp);
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

        public Utente? Get(int id)
        {
            return _context.Utentes.Find(id);
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utentes.ToList();
        }
        public Utente? GetByNome(string? nome)
        {
            try
            {
                return _context.Utentes.First(u => u.Nome == nome);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public bool Update(Utente entity)
        {
            Utente? temp=GetByNome(entity.Nome);
            if(temp !=null)
            {   
                temp.Indirizzo=entity.Indirizzo;
                temp.Email=entity.Email;
                temp.Pass= entity.Pass;
                try
                {
                    _context.Utentes.Update(temp);
                    _context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;

                }
            }
            return false;

            //try
            //{
            //    _context.Utentes.Update(entity);
            //    _context.SaveChanges();

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    return false;
            //}
        }
    }
}
