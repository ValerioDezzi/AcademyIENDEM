using GestioneEventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEventi.Csv
{
    internal static class CsvManager
    {
        public static string pathEventi = "C:\\Users\\valer\\Desktop\\EventiCsv.txt";
        public static string pathPartecipanti = "C:\\Users\\valer\\Desktop\\PartecipantiCsv.txt";
        public static string pathRisorse = "C:\\Users\\valer\\Desktop\\RisorseCsv.txt";
        public static void esportaEvento(Evento e)
        {
            if (e is not null)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(pathEventi))
                    {
                        sw.WriteLine(e.esportaCsv());

                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } 
        }
        
       public static void esportaPartecipante(Partecipante p)
        {
            if (p is not null)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(pathPartecipanti))
                    {
                        sw.WriteLine(p.EsportaCsv());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void esportaRisorsa(Risorsa r)
        {
            if (r is not null)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(pathRisorse))
                    {
                        sw.WriteLine(r.EsportaCsv());

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}
