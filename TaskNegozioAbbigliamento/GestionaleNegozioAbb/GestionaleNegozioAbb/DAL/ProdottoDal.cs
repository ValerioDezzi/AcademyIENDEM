using GestionaleNegozioAbb.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleNegozioAbb.DAL
{
    internal class ProdottoDal : IDal<Prodotti>
    {
        #region Singleton
        private static ProdottoDal? instance;

        public static ProdottoDal getInstance()
        {
            if (instance == null)
            {
                instance = new ProdottoDal();
            }
            return instance;
        }
        private ProdottoDal() { }
#endregion
        public List<Prodotti> GetAll()
        {
            List < Prodotti > risultato= new List<Prodotti>();

            using(NegozioAbbigliamentoContext ctx = new NegozioAbbigliamentoContext())
            {
                try
                {
                    risultato = ctx.Prodottis.ToList();
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        public bool Insert(Prodotti t)
        {
            bool risultato = false;
            using(NegozioAbbigliamentoContext ctx= new NegozioAbbigliamentoContext())
            {
                try
                {
                    ctx.Prodottis.Add(t);
                    ctx.SaveChanges();
                    risultato= true;

                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
        }

        

        public bool Delete(Prodotti prodotto)
        {
            bool risultato = false;
            using (NegozioAbbigliamentoContext ctx = new NegozioAbbigliamentoContext())
            {
                try
                {
                    
                    ctx.Entry(prodotto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    ctx.SaveChanges();
                    risultato= true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return risultato;
 
        }

        public bool Update(Prodotti prodottoDaModificare)
        {
            bool risultato = false;
            try
            {
                using (NegozioAbbigliamentoContext ctx = new NegozioAbbigliamentoContext())
                {

                    // Verifica se il prodotto esiste nel contesto
                    Prodotti? prodottoEsistente = ctx.Prodottis.FirstOrDefault(p => p.ProdottoId == prodottoDaModificare.ProdottoId);
                    if (prodottoEsistente != null)
                    {
                        var entry = ctx.Entry(prodottoEsistente);
                        entry.CurrentValues.SetValues(prodottoDaModificare);
                        ctx.SaveChanges();
                        risultato = true;
                    }
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return risultato;
        }


    }
}
