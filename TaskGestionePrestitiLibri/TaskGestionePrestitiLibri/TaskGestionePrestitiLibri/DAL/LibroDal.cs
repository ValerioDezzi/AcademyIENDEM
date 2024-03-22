using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskGestionePrestitiLibri.Models;
using TaskGestionePrestitiLibri.Utilities;

namespace TaskGestionePrestitiLibri.DAL
{
    internal class LibroDal : IDal<Libro>
    {


        #region Singleton
        private static LibroDal? instance;
        public static LibroDal GetInstance()
        {
            if (instance == null)
                instance = new LibroDal();
            return instance;
        }
        private LibroDal() { }

        #endregion
        #region CRUD
        public bool Delete(Libro t)
        {
            throw new NotImplementedException();
        }

        public List<Libro> GetAll()
        {
            throw new NotImplementedException();
        }

        public Libro GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Libro t)
        {
            bool risultato = false;
            using(SqlConnection con= new SqlConnection(Config.getInstance().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Libro(titolo,annoPubblicazione,disponibilita) VALUES(@titoloVal,@annoPubbVal,@dispVal)";
                sqlCommand.Parameters.AddWithValue("@titoloVal", t.Titolo);
                sqlCommand.Parameters.AddWithValue("@annoPubbVal", t.AnnoPubblicazione);
                sqlCommand.Parameters.AddWithValue("@dispVal", t.isDisponibile);
                
                try
                {
                    con.Open();
                    if(sqlCommand.ExecuteNonQuery()>0)
                        risultato=true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally 
                { 
                    con.Close();
                }
            }

            return risultato;
        }

        public bool Update(Libro t)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
